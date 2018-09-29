using Microsoft.UI.Xaml.Controls.AnimatedVisualPlayer;
using System;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace LottieTest
{
    public sealed partial class LoadingPerfExerciser : Page
    {
        public LoadingPerfExerciser()
        {
            this.InitializeComponent();
        }

        async void Button_Click(object sender, RoutedEventArgs e)
        {
            ((Button)sender).IsEnabled = false;
            await DoExerciseLoading();
            ((Button)sender).IsEnabled = true;
        }

        async Task DoExerciseLoading()
        {
            await ExerciseLoading();
            for (var i = 0; i < 3; i++)
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }

        async Task ExerciseLoading()
        {

            for (var i = 0; i < 1000; i++)
            {
                // Wait for the load. This does not wait for the instantiation.
                //                await lottieSource.SetSourceAsync(new Uri("ms-appx:///assets/LottieLogo1.json"));
                player.Source = new AnimatedVisuals.Empty_box();

                // Wait for the lottie to load.
                await WaitForCompositionLoadChange(true);

                // Set the source to null to force unload.
                //await lottieSource.SetSourceAsync((Uri)null);
                player.Source = null;

                // Wait for the lottie to unload.
                await WaitForCompositionLoadChange(false);
            }
        }

        Task<bool> WaitForCompositionLoadChange(bool loadState)
        {
            var currentTaskSource = new TaskCompletionSource<bool>();

            if (player.IsAnimatedVisualLoaded == loadState)
            {
                currentTaskSource.SetResult(loadState);
            }
            else
            {
                // Register to get loading callbacks from the player.
                long token = 0;
                token = player.RegisterPropertyChangedCallback(AnimatedVisualPlayer.IsAnimatedVisualLoadedProperty, Callback);

                void Callback(DependencyObject dObj, DependencyProperty dProp)
                {
                    if (player.IsAnimatedVisualLoaded == loadState)
                    {
                        currentTaskSource.SetResult(loadState);
                        player.UnregisterPropertyChangedCallback(AnimatedVisualPlayer.IsAnimatedVisualLoadedProperty, token);
                    }
                }
            }
            return currentTaskSource.Task;
        }
    }
}
