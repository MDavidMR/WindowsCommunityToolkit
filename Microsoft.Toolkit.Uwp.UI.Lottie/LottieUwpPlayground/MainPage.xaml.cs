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

        TaskCompletionSource<bool> _jukeboxWaitingForManualMode;

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
                    _player.LoopAnimation = false;

                    while (true)
                    {
                        foreach (var file in files)
                        {
                            while (true)
                            {
                                await PlayFile(file);
                                if (_playVersion != playVersion)
                                {
                                    goto PlayNotCurrent;
                                }

                                if (_playControl.IsOn)
                                {
                                    // We're in manual mode. Wait until we're out of manual mode and play again.
                                    _jukeboxWaitingForManualMode = new TaskCompletionSource<bool>();
                                    await _jukeboxWaitingForManualMode.Task;

                                    if (_playVersion != playVersion)
                                    {
                                        goto PlayNotCurrent;
                                    }
                                }
                                else
                                {
                                    // In automatic mode. Keep going to the next file.
                                    break;
                                }
                            }
                        }
                    }
                    PlayNotCurrent:;
                }
                else
                {
                    // Single file. 

                    // Turn on looping.
                    _player.LoopAnimation = true;

                    // If we were in manual play control, turn it back to automatic.
                    if (_playControl.IsOn)
                    {
                        _playControl.IsOn = false;
                    }
                    await PlayFile(files.First());
                }
            }
        }

        Task PlayFile(StorageFile file)
        {
            // Load the Lottie composition.
            return PlayLottieComposition(new LottieComposition(file)
            {
                Options = LottieCompositionOptions.All
            });
        }

        Task PlaySingleUri(Uri uri)
        {
            // Turn on looping.
            _player.LoopAnimation = true;

            // If we were in manual play control, turn it back to automatic.
            if (_playControl.IsOn)
            {
                _playControl.IsOn = false;
            }

            // Load the Lottie composition.
            return PlayLottieComposition(new LottieComposition()
            {
                UriSource = uri.OriginalString,
                Options = LottieCompositionOptions.All
            });
        }

        async Task PlayLottieComposition(LottieComposition composition)
        {
            _player.Source = composition;
            // Reset the scrubber to the 0 position. 
            _scrubber.Value = 0;

            // Play the file.
            await _player.PlayAsync();

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
                    var filteredItems = items.Where(IsJsonFile);

                    if (filteredItems.Any())
                    {
                        e.AcceptedOperation = DataPackageOperation.Copy;
                        e.DragUIOverride.Caption = filteredItems.Skip(1).Any()
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
                Play(items.Cast<StorageFile>().Where(IsJsonFile));
            }
            finally
            {
                deferral.Complete();
            }
        }

        static bool IsJsonFile(IStorageItem item) => item.IsOfType(StorageItemTypes.File) && item.Name.EndsWith(".json", StringComparison.InvariantCultureIgnoreCase);

        #endregion DragNDrop


        void LottieXmlCopyToClipboardButton_Click(object sender, RoutedEventArgs e)
        {
            CopyTextToClipboard((_player.Diagnostics as LottieCompositionDiagnostics)?.LottieXml);
        }

        void WinCompXmlCopyToClipboardButton_Click(object sender, RoutedEventArgs e)
        {
            CopyTextToClipboard((_player.Diagnostics as LottieCompositionDiagnostics)?.WinCompXml);
        }

        void WinCompCSharpCopyToClipboardButton_Click(object sender, RoutedEventArgs e)
        {
            CopyTextToClipboard((_player.Diagnostics as LottieCompositionDiagnostics)?.WinCompCSharp);
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

        void ProgressSliderChanged(object sender, Windows.UI.Xaml.Controls.Primitives.RangeBaseValueChangedEventArgs e)
        {
            _player.SetProgress(e.NewValue);
        }

        void _playControl_Toggled(object sender, RoutedEventArgs e)
        {
            // If no Lottie is loaded, do nothing.
            if (!_player.IsCompositionLoaded)
            {
                return;
            }

            // Otherwise, if we toggled on, we're in manual mode: set the progress.
            //            If we toggled off, we're in auto mode, start playing.
            if (_playControl.IsOn)
            {
                _player.SetProgress(_scrubber.Value);
            }
            else
            {
                if (_jukeboxWaitingForManualMode != null)
                {
                    // Signal the jukebox to keep going.
                    _jukeboxWaitingForManualMode.SetResult(true);
                    _jukeboxWaitingForManualMode = null;
                }
                else
                {
                    _player.Play();
                }
            }
        }

        async void PlayUrl()
        {
            var url = _urlPicker.Text;
            _urlPicker.Text = "";
            if (string.IsNullOrWhiteSpace(url))
            {
                return;
            }

            var uri = new Uri(url);
            if (uri.IsWellFormedOriginalString())
            {
                await PlaySingleUri(uri);
            }
        }
        void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            PlayUrl();
        }

        void TextBox_KeyDown(object sender, Windows.UI.Xaml.Input.KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                PlayUrl();
            }
        }
    }

    public sealed class LottieCompositionDiagnosticsFormatter : IValueConverter
    {
        static string MSecs(TimeSpan timeSpan) => $"{timeSpan.TotalMilliseconds.ToString("#,##0.0")} mSecs";

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
                        return DiagnosticsToProperties(diagnostics).ToArray();
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

        IEnumerable<Tuple<string, string>> DiagnosticsToProperties(LottieCompositionDiagnostics diagnostics)
        {
            yield return Tuple.Create("File name", diagnostics.FileName);
            yield return Tuple.Create("Duration", $"{diagnostics.Duration.TotalSeconds.ToString("#,##0.000")} secs");
            yield return Tuple.Create("Size", $"{diagnostics.LottieWidth} x {diagnostics.LottieHeight}");
            yield return Tuple.Create("Read", MSecs(diagnostics.ReadTime));
            yield return Tuple.Create("Parse", MSecs(diagnostics.ParseTime));
            yield return Tuple.Create("Validation", MSecs(diagnostics.ValidationTime));
            yield return Tuple.Create("Translation", MSecs(diagnostics.TranslationTime));
            yield return Tuple.Create("Instantiation", MSecs(diagnostics.InstantiationTime));
            foreach (var marker in diagnostics.Markers)
            {
                yield return Tuple.Create("Marker", $"{marker.Key}: {marker.Value.ToString("0.0###")}");
            }
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, string language)
        {
            // Only support one way binding.
            throw new NotImplementedException();
        }
    }
}