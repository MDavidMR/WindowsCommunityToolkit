using Lottie.Data;
using Lottie.Json;
using Lottie.Wuc;
using System;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI;
using Windows.UI.Composition;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Hosting;
using Windows.Foundation;

namespace LottieElement
{
    public enum LottieElementState
    {
        Stopped,
        Reading,
        Translating,
        Showing,
        Playing,
    }

    public sealed class LottieElement : FrameworkElement
    {
        readonly ContainerVisual _rootVisual;
        readonly SpriteVisual _backgroundVisual;
        Visual _lottieVisual;
        LottieComposition _lottieComposition;
        ScalarKeyFrameAnimation _playAnimation;
        IDisposable _resources;
        int _outstandingPlays;

        #region Dependency properties
        public static DependencyProperty BackgroundColorProperty { get; } =
            RegisterDependencyProperty(nameof(BackgroundColor), Colors.Transparent, (that, newValue) => that.SetBackgroundColor(newValue));

        public static DependencyProperty DurationProperty { get; } =
            RegisterDependencyProperty(nameof(Duration), (TimeSpan?)null);

        public static DependencyProperty FileProperty { get; } =
            RegisterDependencyProperty(nameof(File), (StorageFile)null, (that, newValue) => that.SetFile(newValue));

        public static DependencyProperty StateProperty { get; } =
            RegisterDependencyProperty(nameof(State), LottieElementState.Stopped);
        #endregion Dependency properties



        public LottieElement()
        {
            var compositor = Window.Current.Compositor;
            _rootVisual = compositor.CreateContainerVisual();
            ElementCompositionPreview.SetElementChildVisual(this, _rootVisual);

            _backgroundVisual = compositor.CreateSpriteVisual();
            _rootVisual.Children.InsertAtTop(_backgroundVisual);

            _backgroundVisual.Brush = compositor.CreateColorBrush(Colors.Blue);
        }

        public Windows.UI.Color BackgroundColor
        {
            get => (Windows.UI.Color)GetValue(BackgroundColorProperty);
            set => SetValue(BackgroundColorProperty, value);
        }

        public TimeSpan? Duration => _lottieComposition == null ? (TimeSpan?)null : _lottieComposition.Duration;

        public StorageFile File
        {
            get => (StorageFile)GetValue(FileProperty);
            set => SetValue(FileProperty, value);
        }

        public LottieElementState State => (LottieElementState)GetValue(StateProperty);

        /// <summary>
        /// Starts or restarts playing the currently loaded Lottie file.
        /// </summary>
        public void StartPlaying()
        {
            if (_lottieVisual != null)
            {
                SetState(LottieElementState.Playing);

                // Increment the animation progress value from 0 to 1.

                var animController = _lottieVisual.TryGetAnimationController(LottieToVisualTranslator.ProgressAnimationName);

                var batch = _lottieVisual.Compositor.CreateScopedBatch(CompositionBatchTypes.Animation);
                if (animController == null) // If not animating, create a new play animation
                {
                    _playAnimation = Window.Current.Compositor.CreateScalarKeyFrameAnimation();
                    _playAnimation.InsertKeyFrame(0, 0);
                    _playAnimation.InsertKeyFrame(1, 1, Window.Current.Compositor.CreateLinearEasingFunction());
                    _playAnimation.Duration = _lottieComposition.Duration;
                    //    IsVisible = true; // TODO: Fix this hack
                }
                _lottieVisual.StartAnimation("AnimationProgress", _playAnimation);
                _outstandingPlays++;

                batch.Completed += (sender, args) =>
                {
                    _outstandingPlays--;
                    if (_outstandingPlays == 0)
                    {
                        SetState(LottieElementState.Showing);
                    }
                };
                batch.End();
            }
        }

        // Keeps the size of the Visuals in sync with the size of the element.
        protected override Size ArrangeOverride(Size finalSize)
        {
            var newSize = new System.Numerics.Vector2((float)finalSize.Width, (float)finalSize.Height);
            _backgroundVisual.Size = newSize;
            if (_lottieVisual != null)
            {
                _lottieVisual.Size = newSize;
            }

            return finalSize;
        }

        void SetState(LottieElementState state) => SetValue(StateProperty, state);

        void SetBackgroundColor(Windows.UI.Color color) => 
            _backgroundVisual.Brush = _backgroundVisual.Compositor.CreateColorBrush(color);        

        async void SetFile(StorageFile file)
        {
            if (file != null)
            {
                SetState(LottieElementState.Reading);
                bool stateTransitionCompleted = false;
                try
                {
                    stateTransitionCompleted = false;
                    var contents = await FileIO.ReadTextAsync(file);
                    _lottieComposition = LottieCompositionJsonReader.ReadLottieCompositionFromJson(contents);

                    SetState(LottieElementState.Translating);


                    if (_resources != null)
                    {
                        // Clean up the old resources.
                        _resources.Dispose();
                    }

                    // Translating the lottie can take significant time. Do it on another thread.
                    var compositor = Window.Current.Compositor;
                    Visual newLottieVisual = null;
                    await Task.Run(() =>
                    {
                        LottieToVisualTranslator.TranslateLottieComposition(_lottieComposition, compositor, out newLottieVisual, out _resources, out TranslationInfo translationInfo);
                    });
                    if (_lottieVisual != null)
                    {
                        _rootVisual.Children.Remove(_lottieVisual);
                    }
                    _rootVisual.Children.InsertAtTop(newLottieVisual);
                    _lottieVisual = newLottieVisual;
                    _lottieVisual.Size = _backgroundVisual.Size;
                    SetState(LottieElementState.Showing);
                    stateTransitionCompleted = true;
                }
                finally
                {
                    if (!stateTransitionCompleted)
                    {
                        SetState(LottieElementState.Stopped);
                    }
                }
            }
        }

        #region DependencyProperty helpers
        static DependencyProperty RegisterDependencyProperty<T>(string propertyName, PropertyMetadata metadata) =>
            DependencyProperty.Register(propertyName, typeof(T), typeof(LottieElement), metadata);

        static DependencyProperty RegisterDependencyProperty<T>(string propertyName, T defaultValue) =>
            DependencyProperty.Register(propertyName, typeof(T), typeof(LottieElement), new PropertyMetadata(defaultValue));

        static DependencyProperty RegisterDependencyProperty<T>(string propertyName, T defaultValue, Action<LottieElement, T> callback) =>
            DependencyProperty.Register(propertyName, typeof(T), typeof(LottieElement),
                new PropertyMetadata(defaultValue, (d, e) => callback(((LottieElement)d), (T)e.NewValue)));
        #endregion DependencyProperty helpers
    }
}
