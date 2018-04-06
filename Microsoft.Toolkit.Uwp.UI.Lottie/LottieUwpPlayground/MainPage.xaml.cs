using Lottie;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Windows.ApplicationModel.DataTransfer;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;

namespace LottieUwpPlayground
{
    public sealed partial class MainPage : Page
    {
        int _playVersion;

        public MainPage()
        {
            InitializeComponent();
#if DEBUG
            var binding = new Binding();
            _player.RegisterPropertyChangedCallback(CompositionPlayer.IsCompositionLoadedProperty, (dobj, dprop) =>
                Debug.WriteLine($"IsCompositionLoaded set to {_player.IsCompositionLoaded}"));

            _player.RegisterPropertyChangedCallback(CompositionPlayer.IsPlayingProperty, (dobj, dprop) =>
                Debug.WriteLine($"IsPlaying set to {_player.IsPlaying}"));
#endif
        }

        async void PickFile_Click(object sender, RoutedEventArgs e)
        {
            var filePicker = new FileOpenPicker()
            {
                ViewMode = PickerViewMode.List,
                SuggestedStartLocation = PickerLocationId.ComputerFolder,
            };
            filePicker.FileTypeFilter.Add(".json");
            Play(await filePicker.PickMultipleFilesAsync());
        }

        async void Play(IEnumerable<StorageFile> files)
        {
            // Used to detect overlapping calls to this method.
            var playVersion = ++_playVersion;

            if (files != null && files.Any())
            {
                // Clear out the currently playing file so the user can see immediately that
                // the play has started, otherwise they might be waiting while the file loads.
                _player.Source = null;

                if (files.Skip(1).Any())
                {
                    // Multiple files. Jukebox mode.

                    // Turn off looping, otherwise we'll never get to the second item.
                    loopingSwitch.IsOn = false;

                    while (true)
                    {
                        foreach (var file in files)
                        {
                            await PlayFile(file, playVersion);
                        }
                    }
                }
                else
                {
                    // Single file. 

                    await PlayFile(files.First(), playVersion);
                }
            }
        }

        async Task PlayFile(StorageFile file, int playVersion)
        {
            var lottie = new LottieComposition(file)
            {
                Options = LottieCompositionOptions.All
            };

            _player.Source = lottie;

            bool previousLoopingSwitchValue;
            do
            {
                // Check whether we got reentered by another request.
                if (_playVersion != playVersion)
                {
                    break;
                }

                previousLoopingSwitchValue = loopingSwitch.IsOn;
                await PlayAsync();
                // If someone toggled the looping switch, restart with the
                // new looping value.
            } while (previousLoopingSwitchValue != loopingSwitch.IsOn);
        }

        #region DragNDrop
        async void LottieDragOverHandler(object sender, DragEventArgs e)
        {
            // Only accept files.
            if (e.DataView.Contains(StandardDataFormats.StorageItems))
            {
                // Get a deferral to keep the drag operation alive until the async
                // methods have completed.
                var deferral = e.GetDeferral();
                try
                {
                    var items = await e.DataView.GetStorageItemsAsync();
                    var filteredItems = items.Where(item =>
                        item.IsOfType(StorageItemTypes.File) &&
                        item.Name.EndsWith(".json", StringComparison.InvariantCultureIgnoreCase));

                    if (filteredItems.Any())
                    {
                        e.AcceptedOperation = DataPackageOperation.Copy;
                        e.DragUIOverride.Caption = items.Skip(1).Any()
                            ? "Drop to view Lotties."
                            : "Drop to view Lottie.";
                    }
                }
                finally
                {
                    deferral.Complete();
                }
            }
        }

        async void LottieDropHandler(object sender, DragEventArgs e)
        {
            var deferral = e.GetDeferral();
            try
            {
                var items = await e.DataView.GetStorageItemsAsync();
                Play(items.Cast<StorageFile>());
            }
            finally
            {
                deferral.Complete();
            }
        }

        #endregion DragNDrop


        void Looping_Toggled(object sender, RoutedEventArgs e)
        {

            // If something is loaded, stop the currently running animation. It will
            // restart with the new looping state.
            if (_player.IsCompositionLoaded)
            {
                _player.Stop();
            }
        }

        int _playAsyncVersion;
        async Task PlayAsync()
        {
            var version = ++_playAsyncVersion;
            // Start the play button animating.
            PlayPauseButton.IsChecked = true;

            //PlayButtonLottie.Play(loop: true);
            await _player.PlayAsync(loopingSwitch.IsOn);
            if (version == _playAsyncVersion)
            {
                PlayPauseButton.IsChecked = false;
            }
        }

        async void PlayPause_Checked(object sender, RoutedEventArgs e)
        {
            await PlayAsync();
        }

        void PlayPause_Unchecked(object sender, RoutedEventArgs e)
        {
            if (_player.IsCompositionLoaded && _player.IsPlaying)
            {
                _player.Pause();
            }
        }

        void LottieXmlCopyToClipboardButton_Click(object sender, RoutedEventArgs e)
        {
            CopyTextToClipboard((_player.Diagnostics as LottieCompositionDiagnostics)?.LottieXml);
        }

        void WinCompXmlCopyToClipboardButton_Click(object sender, RoutedEventArgs e)
        {
            CopyTextToClipboard((_player.Diagnostics as LottieCompositionDiagnostics)?.WinCompXml);
        }

        void CopyTextToClipboard(string text)
        {
            if (!string.IsNullOrWhiteSpace(text))
            {
                var dataPackage = new DataPackage();
                dataPackage.SetText(text);
                Clipboard.SetContent(dataPackage);
            }
        }
    }

    public sealed class LottieCompositionDiagnosticsFormatter : IValueConverter
    {
        object IValueConverter.Convert(object value, Type targetType, object parameter, string language)
        {
            if (parameter as string == "CollapsedIfNull" && targetType == typeof(Visibility))
            {
                return value == null ? Visibility.Collapsed : Visibility.Visible;
            }

            var diagnostics = value as LottieCompositionDiagnostics;

            if (diagnostics != null)
            {
                switch (parameter as string)
                {
                    case "Properties":
                        return new[]
                        {
                            Tuple.Create("File name", diagnostics.FileName, ""),
                            Tuple.Create("Duration", diagnostics.Duration.TotalSeconds.ToString("#,##0.000"), "secs"),
                            Tuple.Create("Parse", diagnostics.ParseTime.TotalMilliseconds.ToString("#,##0.0"), "mSecs"),
                            Tuple.Create("Validation", diagnostics.ValidationTime.TotalMilliseconds.ToString("#,##0.0"), "mSecs"),
                            Tuple.Create("Translation", diagnostics.TranslationTime.TotalMilliseconds.ToString("#,##0.0"), "mSecs"),
                            Tuple.Create("Instantiation", diagnostics.InstantiationTime.TotalMilliseconds.ToString("#,##0.0"), "mSecs"),
                        };
                    case "ParsingIssues":
                        if (targetType == typeof(Visibility))
                        {
                            return diagnostics.JsonParsingIssues.Any() ? Visibility.Visible : Visibility.Collapsed;
                        }
                        else
                        {
                            return diagnostics.JsonParsingIssues.OrderBy(a => a);
                        }
                    case "TranslationIssues":
                        if (targetType == typeof(Visibility))
                        {
                            return diagnostics.TranslationIssues.Any() ? Visibility.Visible : Visibility.Collapsed;
                        }
                        else
                        {
                            return diagnostics.TranslationIssues.OrderBy(a => a);
                        }

                    default:
                        break;
                }
            }
            return null;
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, string language)
        {
            // Only support one way binding.
            throw new NotImplementedException();
        }
    }
}