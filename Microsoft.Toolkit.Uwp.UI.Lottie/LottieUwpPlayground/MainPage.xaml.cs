using Lottie;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Windows.ApplicationModel.DataTransfer;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Hosting;
using Windows.UI.Xaml.Media;

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

            // Connect the player's progress to the scrubber's progress.
            _scrubber.SetAnimatedCompositionObject(_player.ProgressObject);
        }

        async void SaveFile_Click(object sender, RoutedEventArgs e)
        {
            var diagnostics = _player.Diagnostics as LottieCompositionDiagnostics;
            if (diagnostics == null)
            {
                return;
            }

            var filePicker = new FileSavePicker
            {
                SuggestedStartLocation = PickerLocationId.DocumentsLibrary,
                SuggestedFileName = diagnostics?.SuggestedName ?? "Composition",
            };

            // Dropdown of file types the user can save the file as
            filePicker.FileTypeChoices.Add("C#", new[] { ".cs" });
            filePicker.FileTypeChoices.Add("C++ CX", new[] { ".cpp" });
            // cppwinrt not yet implemented. Note that the extension needs to be unique
            // if we're going to recognize the choice when the file is saved.
            //filePicker.FileTypeChoices.Add("C++/WinRT", new[] { ".cpp" });
            filePicker.FileTypeChoices.Add("Lottie XML", new[] { ".xml" });
            // Note that the extension needs to be unique if we're going to 
            // recognize the choice when the file is saved.            
            //filePicker.FileTypeChoices.Add("WinComp XML", new[] { ".xml" });

            var pickedFile = await filePicker.PickSaveFileAsync();

            if (pickedFile == null)
            {
                return;
            }

            switch (pickedFile.FileType)
            {
                case ".cs":
                    await FileIO.WriteTextAsync(pickedFile, diagnostics.WinCompCSharp);
                    break;
                case ".cpp":
                    await FileIO.WriteTextAsync(pickedFile, diagnostics.WinCompCpp);
                    break;
                // cppwinrt not yet implemented
                //case ".cpp":
                //    await FileIO.WriteTextAsync(pickedFile, diagnostics.WinCompCpp);
                //    break;
                case ".xml":
                    await FileIO.WriteTextAsync(pickedFile, diagnostics.LottieXml);
                    break;
                // Can only have one .xml.
                //case ".xml":
                //    await FileIO.WriteTextAsync(pickedFile, diagnostics.WinCompXml);
                //    break;
                default:
                    throw new InvalidOperationException();
            }
        }

        async void PickFile_Click(object sender, RoutedEventArgs e)
        {
            var filePicker = new FileOpenPicker
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
                _playerSource.UriSource = null;

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
                                await PlayFile(file, playVersion);
                                if (_playVersion != playVersion)
                                {
                                    goto PlayNotCurrent;
                                }

                                if (_playStopButton.IsChecked.Value)
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

                    // If we were stopped in manual play control, turn it back to automatic.
                    if (!_playStopButton.IsChecked.Value)
                    {
                        _playStopButton.IsChecked = true;
                    }
                    await PlayFile(files.First(), playVersion);
                }
            }
        }

        async Task PlayFile(StorageFile file, int playVersion)
        {
            using (new LoadingAnimationHandler(this))
            {
                try
                {
                    // Load the Lottie composition.
                    await _playerSource.SetSourceAsync(file);
                }
                catch (Exception)
                {
                    // Failed to load.
                    return;
                }

                // Reset the scrubber to the 0 position. 
                _scrubber.Value = 0;
            }

            if (playVersion != _playVersion)
            {
                return;
            }

            if (_player.IsCompositionLoaded)
            {
                // Play the file.
                _scrubber.Value = 0;
                await _player.PlayAsync();
            }
        }

        async Task PlaySingleUri(Uri uri)
        {
            var playVersion = ++_playVersion;

            using (new LoadingAnimationHandler(this))
            {
                // Turn on looping.
                _player.LoopAnimation = true;

                // If we were stopped in manual play control, turn it back to automatic.
                if (!_playStopButton.IsChecked.Value)
                {
                    _playStopButton.IsChecked = true;
                }

                // Load the Lottie composition.
                await _playerSource.SetSourceAsync(uri);

                // Reset the scrubber to the 0 position. 
                _scrubber.Value = 0;
            }

            if (playVersion != _playVersion)
            {
                return;
            }

            // Play the file.
            _scrubber.Value = 0;
            await _player.PlayAsync();
        }

        sealed class LoadingAnimationHandler : IDisposable
        {
            readonly MainPage _owner;
            readonly Task _task;
            bool _isDisposed;

            internal LoadingAnimationHandler(MainPage owner)
            {
                _owner = owner;
                _task = Start();
            }

            async Task Start()
            {
                _owner._player.Visibility = Visibility.Collapsed;

                // Wait for 300 mS.
                await Task.Delay(300);
                if (!_isDisposed)
                {
                    _owner._loadingAnimation.Play();
                    _owner._loadingAnimation.Visibility = Visibility.Visible;
                }
            }
            public void Dispose()
            {
                _isDisposed = true;
                // Hide and stop the loading animation.
                _owner._loadingAnimation.Visibility = Visibility.Collapsed;
                _owner._loadingAnimation.Stop();
                _owner._player.Visibility = Visibility.Visible;
            }
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


        bool _ignoreScrubberValueChanges;

        void ProgressSliderChanged(object sender, Windows.UI.Xaml.Controls.Primitives.RangeBaseValueChangedEventArgs e)
        {
            if (!_ignoreScrubberValueChanges)
            {
                _playStopButton.IsChecked = false;
                _player.SetProgress(e.NewValue);
            }
        }

        void _playControl_Toggled(object sender, RoutedEventArgs e)
        {
            // If no Lottie is loaded, do nothing.
            if (!_player.IsCompositionLoaded)
            {
                return;
            }

            // Otherwise, if we toggled on, we're stopped in manual mode: set the progress.
            //            If we toggled off, we're in auto mode, start playing.
            if (!_playStopButton.IsChecked.Value)
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
                    _ignoreScrubberValueChanges = true;
                    _scrubber.Value = 0;
                    _ignoreScrubberValueChanges = false;
                    _player.Play();
                }
            }
        }
    }

    public sealed class VisiblityConverter : IValueConverter
    {
        object IValueConverter.Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is bool boolValue)
            {
                if ((string)parameter == "not")
                {
                    boolValue = !boolValue;
                }
                return boolValue ? Visibility.Visible : Visibility.Collapsed;
            }
            return null;
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, string language)
        {
            // Only support one way binding.
            throw new NotImplementedException();
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

            switch (parameter as string)
            {
                case "Properties":
                    if (diagnostics == null) { return null; }
                    return DiagnosticsToProperties(diagnostics).ToArray();
                case "ParsingIssues":
                    if (diagnostics == null) { return null; }
                    if (targetType == typeof(Visibility))
                    {
                        return diagnostics.JsonParsingIssues.Any() ? Visibility.Visible : Visibility.Collapsed;
                    }
                    else
                    {
                        return diagnostics.JsonParsingIssues.OrderBy(a => a);
                    }
                case "TranslationIssues":
                    if (diagnostics == null) { return null; }
                    if (targetType == typeof(Visibility))
                    {
                        return diagnostics.TranslationIssues.Any() ? Visibility.Visible : Visibility.Collapsed;
                    }
                    else
                    {
                        return diagnostics.TranslationIssues.OrderBy(a => a);
                    }
                case "VisibleIfIssues":
                    if (diagnostics == null)
                    {
                        return Visibility.Collapsed;
                    }
                    return diagnostics.JsonParsingIssues.Any() || diagnostics.TranslationIssues.Any() ? Visibility.Visible : Visibility.Collapsed;
                default:
                    break;

            }
            return null;
        }

        IEnumerable<Tuple<string, string>> DiagnosticsToProperties(LottieCompositionDiagnostics diagnostics)
        {
            yield return Tuple.Create("File name", diagnostics.FileName);
            yield return Tuple.Create("Duration", $"{diagnostics.Duration.TotalSeconds.ToString("#,##0.0##")} secs");
            var aspectRatio = FloatToRatio(diagnostics.LottieWidth / diagnostics.LottieHeight);
            yield return Tuple.Create("Aspect ratio", $"{aspectRatio.Item1.ToString("0.###")}:{aspectRatio.Item2.ToString("0.###")}");
            yield return Tuple.Create("Size", $"{diagnostics.LottieWidth} x {diagnostics.LottieHeight}");
            yield return Tuple.Create("Version", diagnostics.LottieVersion);
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

        // Returns a pleasantly simplified ratio for the given value.
        static ValueTuple<double, double> FloatToRatio(double value)
        {
            const int maxNumeratorOrDenominator = 30;
            var candidateNumerator = 1.0;
            var candidateDenominator = 1.0;
            var error = Math.Abs(value - 1);

            for (double n = candidateNumerator, d = candidateDenominator; n <= maxNumeratorOrDenominator && d <= maxNumeratorOrDenominator && error != 0;)
            {
                if (value > n / d)
                {
                    n++;
                }
                else
                {
                    d++;
                }

                var newError = Math.Abs(value - (n / d));
                if (newError < error)
                {
                    error = newError;
                    candidateNumerator = n;
                    candidateDenominator = d;
                }
            }

            // If we gave up because the numerator or denominator got too big then
            // the number is an approximation that requires some decimal places.
            // Get the real ratio by adjusting the denominator or numerator - whichever
            // requires the smallest adjustment.
            if (error != 0)
            {
                if (value > candidateNumerator / candidateDenominator)
                {
                    candidateNumerator = candidateDenominator * value;
                }
                else
                {
                    candidateDenominator = candidateNumerator / value;
                }
            }

            return ValueTuple.Create(candidateNumerator, candidateDenominator);
        }
    }
}