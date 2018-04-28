using Compositions;
using Lottie;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace LottieUwpPlayground
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    sealed partial class App : Application
    {
        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            this.InitializeComponent();
            this.Suspending += OnSuspending;
        }

        // Starts the animated splash screen as content for the current window. The
        // returned IAsyncAction completes when the animation finishes.
        IAsyncAction StartAnimatedSplashScreenAsync()
        {
            var compositionPlayer = new CompositionPlayer
            {
                Stretch = Stretch.UniformToFill,
                AutoPlay = false,
                LoopAnimation = false,
                FromProgress = 0,
                ToProgress = 0.595,
                Source = new LottieLogo1Composition()
            };
            Window.Current.Content = compositionPlayer;
            // Start playing.
            return compositionPlayer.PlayAsync();
        }

        /// <summary>
        /// Invoked when the application is launched normally by the end user.  Other entry points
        /// will be used such as when the application is launched to open a specific file.
        /// </summary>
        /// <param name="e">Details about the launch request and process.</param>
        protected override async void OnLaunched(LaunchActivatedEventArgs e)
        {
            InitializeTitleBarColors();

            Frame rootFrame = Window.Current.Content as Frame;

            // Do not repeat app initialization when the Window already has content,
            // just ensure that the window is active
            if (rootFrame == null)
            {
                // Create a Frame to act as the navigation context and navigate to the first page
                rootFrame = new Frame();

                rootFrame.NavigationFailed += OnNavigationFailed;

                if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {
                    //TODO: Load state from previously suspended application
                }

                // Place the frame in the current Window
                Window.Current.Content = rootFrame;
            }

            if (!e.PrelaunchActivated)
            {
                // Start the splash screen animation. This will replace the window content.
                var splashScreenTask = StartAnimatedSplashScreenAsync().AsTask();

                // Ensure the current window is active
                Window.Current.Activate();

                // Start navigation to the first page. This will continue
                // while the splash screen finishes animating.
                rootFrame.Navigate(typeof(MainPage), e.Arguments);

                // Wait for the animation to finish.
                await splashScreenTask;

                // Replace the splash screen animation with the frame.
                Window.Current.Content = rootFrame;
            }

        }

        void InitializeTitleBarColors()
        {
            var titleBar = ApplicationView.GetForCurrentView().TitleBar;
            if (titleBar != null)
            {
                var backgroundColor = (SolidColorBrush)Current.Resources["BackgroundBrush"];
                var foregroundColor = (SolidColorBrush)Current.Resources["ForegroundBrush"];
                titleBar.ButtonBackgroundColor = backgroundColor.Color;
                titleBar.ButtonForegroundColor = foregroundColor.Color;
                titleBar.BackgroundColor = backgroundColor.Color;
                titleBar.ForegroundColor = foregroundColor.Color;
            }
        }

        /// <summary>
        /// Invoked when Navigation to a certain page fails
        /// </summary>
        /// <param name="sender">The Frame which failed navigation</param>
        /// <param name="e">Details about the navigation failure</param>
        void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
        }

        /// <summary>
        /// Invoked when application execution is being suspended.  Application state is saved
        /// without knowing whether the application will be terminated or resumed with the contents
        /// of memory still intact.
        /// </summary>
        /// <param name="sender">The source of the suspend request.</param>
        /// <param name="e">Details about the suspend request.</param>
        private void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();
            //TODO: Save application state and stop any background activity
            deferral.Complete();
        }
    }
}
