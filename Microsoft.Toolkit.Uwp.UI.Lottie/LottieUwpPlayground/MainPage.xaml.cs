using System;
using System.Linq;
using Windows.ApplicationModel.DataTransfer;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;

namespace LottieUwpPlayground
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        //void CreateCompRoot()
        //{

        //    shapeVisual.Size = new Vector2((float)Host.ActualWidth, (float)Host.ActualHeight);
        //    ElementCompositionPreview.SetElementChildVisual(Host, shapeVisual);

        //    // Set slider properties
        //    ProgressSlider.Minimum = _lottieComposition.StartFrame;
        //    ProgressSlider.Maximum = _lottieComposition.EndFrame;
        //    ProgressSlider.ValueChanged += ProgressSlider_ValueChanged;

        //    SpeedSlider.Value = 1;
        //    SpeedSlider.ValueChanged += SpeedSlider_ValueChanged;
        //}


        void ProgressSlider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            //_lottieCompositionPlayer.Progress = (float)e.NewValue;
        }

        void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            lottiePlayer.StartPlaying();
        }

        async void PickFile_Click(object sender, RoutedEventArgs e)
        {
            var filePicker = new FileOpenPicker()
            {
                ViewMode = PickerViewMode.List,
                SuggestedStartLocation = PickerLocationId.ComputerFolder,
            };
            filePicker.FileTypeFilter.Add(".json");
            var pickedFile = await filePicker.PickSingleFileAsync();
            if (pickedFile != null)
            {
                lottiePlayer.File = pickedFile;
            }
        }

        void PauseButton_Click(object sender, RoutedEventArgs e)
        {
            // Toggle
            lottiePlayer.IsPaused = !lottiePlayer.IsPaused;
        }

        void SpeedSlider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            //_lottieCompositionPlayer.Speed = (float)e.NewValue;
        }

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

                    // Only accept a single file.
                    if (!items.Skip(1).Any())
                    {
                        var item = items.First();

                        // Only accept files that have the ".json" extension.
                        if (item.IsOfType(Windows.Storage.StorageItemTypes.File) &&
                            item.Name.EndsWith(".json", StringComparison.InvariantCultureIgnoreCase))
                        {
                            e.DragUIOverride.Caption = "Drop to view Lottie.";
                            e.AcceptedOperation = DataPackageOperation.Copy;
                        }
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
                var item = (await e.DataView.GetStorageItemsAsync()).First();
                var file = (StorageFile)item;
                lottiePlayer.File = file;
            }
            finally
            {
                deferral.Complete();
            }
        }

    }
}