using Lottie;
using Microsoft.UI.Xaml.Controls.CompositionPlayer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace LottieTest
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LoadingPerfExerciser : Page
    {
        public LoadingPerfExerciser()
        {
            this.InitializeComponent();
            ExerciseLoading();
        }

        async void ExerciseLoading()
        {

            while (true)
            {
                // Wait for the load. This does not wait for the instantiation.
                await lottieSource.SetSourceAsync(new Uri("ms-appx:///assets/LottieLogo1.json"));

                // Wait for the lottie to load.
                await WaitForCompositionLoadChange(true);

                // Set the source to null to force unload.
                await lottieSource.SetSourceAsync((Uri)null);

                // Wait for the lottie to unload.
                await WaitForCompositionLoadChange(false);
            }
        }

        Task<bool> WaitForCompositionLoadChange(bool loadState)
        {
            var currentTaskSource = new TaskCompletionSource<bool>();

            if (player.IsCompositionLoaded == loadState)
            {
                currentTaskSource.SetResult(loadState);
            }
            else
            {
                // Register to get loading callbacks from the player.
                long token = 0;
                token = player.RegisterPropertyChangedCallback(CompositionPlayer.IsCompositionLoadedProperty, Callback);

                void Callback(DependencyObject dObj, DependencyProperty dProp)
                {
                    if (player.IsCompositionLoaded == loadState)
                    {
                        currentTaskSource.SetResult(loadState);
                        player.UnregisterPropertyChangedCallback(CompositionPlayer.IsCompositionLoadedProperty, token);
                    }
                }
            }
            return currentTaskSource.Task;
        }
    }
}
