using Lottie.Data;
using Lottie.Json;
using Lottie.Wuc;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Storage;
using Windows.UI;
using Windows.UI.Composition;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Hosting;

namespace Lottie
{
    public enum LottiePlayerState
    {
        NoLottieLoaded,
        Reading,
        Translating,
        Stopped,
        Playing,
        PlayingPaused,
    }

    public sealed class LottiePlayer : FrameworkElement
    {
        readonly ContainerVisual _rootVisual;
        readonly SpriteVisual _backgroundVisual;
        readonly ScalarKeyFrameAnimation _playAnimation;
        readonly ScalarKeyFrameAnimation _loopPlayAnimation;
        Visual _lottieVisual;
        LottieComposition _lottieComposition;
        IDisposable _resources;
        // Counts each state transition so that async code can detect when states
        // change underneath them.
        int _stateTransitionCounter;
        int _outstandingPlays;

        #region Dependency properties

        public static DependencyProperty AutoPlayProperty { get; } =
            RegisterDependencyProperty(nameof(AutoPlay), false);

        public static DependencyProperty BackgroundColorProperty { get; } =
            RegisterDependencyProperty(nameof(BackgroundColor), Colors.Transparent, (that, newValue) => that.SetBackgroundColor(newValue));

        public static DependencyProperty DiagnosticsProperty { get; } =
            RegisterDependencyProperty(nameof(Diagnostics), (string)null);

        public static DependencyProperty DurationProperty { get; } =
            RegisterDependencyProperty(nameof(Duration), (TimeSpan?)null);

        public static DependencyProperty FileProperty { get; } =
            RegisterDependencyProperty(nameof(File), (StorageFile)null, (that, newValue) => that.SetFile(newValue));

        public static DependencyProperty FileNameProperty { get; } =
            RegisterDependencyProperty(nameof(FileName), (string)null);

        public static DependencyProperty IsLoopingEnabledProperty { get; } =
            RegisterDependencyProperty(nameof(IsLoopingEnabled), false, (that, newValue) => that.SetIsLoopingEnabled(newValue));

        public static DependencyProperty IsPausedProperty { get; } =
            RegisterDependencyProperty(nameof(IsPaused), false, (that, newValue) => that.SetIsPaused(newValue));

        public static DependencyProperty StateProperty { get; } =
            RegisterDependencyProperty(nameof(State), LottiePlayerState.NoLottieLoaded);
        #endregion Dependency properties


        public LottiePlayer()
        {
            Unloaded += (sender, e) => DisposeResources();

            var compositor = Window.Current.Compositor;

            // Set up the Visual tree.
            _rootVisual = compositor.CreateContainerVisual();
            ElementCompositionPreview.SetElementChildVisual(this, _rootVisual);
            _backgroundVisual = compositor.CreateSpriteVisual();
            _rootVisual.Children.InsertAtTop(_backgroundVisual);

            // Create the play and loopPlay animations. Durations must be set later
            // when the LottieComposition is read.
            var linearEasing = compositor.CreateLinearEasingFunction();

            _playAnimation = compositor.CreateScalarKeyFrameAnimation();
            _playAnimation.InsertKeyFrame(0, 0);
            _playAnimation.InsertKeyFrame(1, 1, linearEasing);

            _loopPlayAnimation = compositor.CreateScalarKeyFrameAnimation();
            _loopPlayAnimation.InsertKeyFrame(0, 0);
            _loopPlayAnimation.InsertKeyFrame(1, 1, linearEasing);
            _loopPlayAnimation.IterationBehavior = AnimationIterationBehavior.Forever;
        }


        public bool AutoPlay
        {
            get => (bool)GetValue(AutoPlayProperty);
            set => SetValue(AutoPlayProperty, value);
        }

        public Windows.UI.Color BackgroundColor
        {
            get => (Windows.UI.Color)GetValue(BackgroundColorProperty);
            set => SetValue(BackgroundColorProperty, value);
        }

        public string Diagnostics => (string)GetValue(DiagnosticsProperty);

        public TimeSpan? Duration => (TimeSpan?)GetValue(DurationProperty);

        public StorageFile File
        {
            get => (StorageFile)GetValue(FileProperty);
            set => SetValue(FileProperty, value);
        }

        public string FileName => (string)GetValue(FileNameProperty);

        public bool IsLoopingEnabled
        {
            get => (bool)GetValue(IsLoopingEnabledProperty);
            set => SetValue(IsLoopingEnabledProperty, value);
        }

        public bool IsPaused
        {
            get => (bool)GetValue(IsPausedProperty);
            set => SetValue(IsPausedProperty, value);
        }

        public LottiePlayerState State => (LottiePlayerState)GetValue(StateProperty);


        /// <summary>
        /// Starts or restarts playing the currently loaded Lottie file from the start.
        /// </summary>
        public void StartPlaying()
        {
            if (_lottieVisual != null)
            {
                // Start or restart an aninmation that advances the Progress from 0 to 1.

                KeyFrameAnimation animation;
                CompositionScopedBatch batch = null;
                if (IsLoopingEnabled)
                {
                    animation = _loopPlayAnimation;
                }
                else
                {
                    animation = _playAnimation;
                    // Batches only work and make sense for non-looping animations.
                    batch = _lottieVisual.Compositor.CreateScopedBatch(CompositionBatchTypes.Animation);
                }

                animation.Duration = _lottieComposition.Duration;

                _lottieVisual.StartAnimation(LottieToVisualTranslator.ProgressPropertyName, animation);


                if (IsPaused)
                {
                    GetAnimationController().Pause();
                    AdvanceToState(LottiePlayerState.PlayingPaused);
                }
                else
                {
                    AdvanceToState(LottiePlayerState.Playing);
                }


                if (!IsLoopingEnabled)
                {
                    // TODO - this counting is almost certainly wrong when switching between looping and non-looping.
                    _outstandingPlays++;
                    batch.Completed += (sender, args) =>
                    {
                        _outstandingPlays--;
                        if (_outstandingPlays == 0)
                        {
                            AdvanceToState(LottiePlayerState.Stopped);
                        }
                    };
                    batch.End();
                }
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

        void AdvanceToState(LottiePlayerState state)
        {
            var oldState = State;
            SetValue(StateProperty, state);

            // Increment the counter so that async calls can detect unexpected state changes.
            _stateTransitionCounter++;

            switch (state)
            {
                case LottiePlayerState.NoLottieLoaded:
                    SetValue(FileNameProperty, null);
                    SetValue(DurationProperty, null);
                    break;
                case LottiePlayerState.Reading:
                    break;
                case LottiePlayerState.Translating:
                    break;
                case LottiePlayerState.Stopped:
                    if (oldState == LottiePlayerState.Translating && AutoPlay)
                    {
                        // Autoplay is on, and a Lottie file just loaded. Play it.
                        StartPlaying();
                    }
                    break;
                case LottiePlayerState.Playing:
                    break;
                case LottiePlayerState.PlayingPaused:
                    break;
                default:
                    throw new InvalidOperationException();
            }
        }

        void SetBackgroundColor(Windows.UI.Color color) =>
            _backgroundVisual.Brush = _backgroundVisual.Compositor.CreateColorBrush(color);

        async void SetFile(StorageFile file)
        {
            if (file != null)
            {
                // TODO - stop the currently playing Lottie if any.
                AdvanceToState(LottiePlayerState.Reading);

                DisposeResources();
                SetValue(FileNameProperty, file.Name);
                SetValue(DiagnosticsProperty, null);
                SetValue(DurationProperty, null);

                var state = CaptureState();
                bool canceled = false;
                try
                {
                    var contents = await FileIO.ReadTextAsync(file);

                    if (canceled |= state.HasChanged)
                    {
                        return;
                    }

                    var sw = Stopwatch.StartNew();

                    string[] readerIssues;
                    _lottieComposition = LottieCompositionJsonReader.ReadLottieCompositionFromJson(contents, out readerIssues);
                    var readerReport = string.Join("\r\n", readerIssues);
                    readerReport = string.Join("\r\n", readerReport, $"Reading time: {sw.Elapsed}");

                    SetValue(DiagnosticsProperty, readerReport);
                    
                    if (_lottieComposition == null)
                    {
                        return;
                    }
                    SetValue(DurationProperty, _lottieComposition.Duration);

                    AdvanceToState(LottiePlayerState.Translating);


                    // Translating large Lotties can take significant time. Do it on another thread.
                    var compositor = Window.Current.Compositor;
                    Visual newLottieVisual = null;
                    state = CaptureState();

                    TranslationInfo translationInfo = null;
                    bool translateSucceeded = false;
                    await Task.Run(() =>
                    {
                        translateSucceeded = LottieToVisualTranslator.TryTranslateLottieComposition(_lottieComposition, compositor, out newLottieVisual, out _resources, out translationInfo);
                    });

                    canceled = !translateSucceeded;
                    if (canceled |= state.HasChanged)
                    {
                        return;
                    }

                    var translationReport = translationInfo?.ToString();
                    SetValue(DiagnosticsProperty, string.IsNullOrEmpty(Diagnostics) ? translationReport : $"{Diagnostics}\r\n{translationReport}");

                    // Replace the old Lottie Visual
                    if (_lottieVisual != null)
                    {
                        _rootVisual.Children.Remove(_lottieVisual);
                    }

                    _rootVisual.Children.InsertAtTop(newLottieVisual);
                    _lottieVisual = newLottieVisual;
                    _lottieVisual.Size = _backgroundVisual.Size;

                    AdvanceToState(LottiePlayerState.Stopped);
                }
                finally
                {
                    if (canceled)
                    {
                        AdvanceToState(LottiePlayerState.NoLottieLoaded);
                    }
                }
            }
        }

        void SetIsLoopingEnabled(bool loopingEnabled)
        {
            // TODO
            // If currently playing, and looping, do nothing.
            // If currently playing and not looping, restart playing with looping enabled - ideally from the same point.
            // If not playing, nothing to do.
        }

        void SetIsPaused(bool isPaused)
        {
            var controller = GetAnimationController();
            if (State == LottiePlayerState.Playing && isPaused)
            {
                controller.Pause();
                AdvanceToState(LottiePlayerState.PlayingPaused);
            }
            else if (State == LottiePlayerState.PlayingPaused && !isPaused)
            {
                controller.Resume();
                AdvanceToState(LottiePlayerState.Playing);
            }
        }

        // Returns the animation controller for the currently playing animation.
        AnimationController GetAnimationController() =>
            _lottieVisual.TryGetAnimationController(LottieToVisualTranslator.ProgressPropertyName);

        void DisposeResources() => _resources?.Dispose();

        #region DependencyProperty helpers
        static DependencyProperty RegisterDependencyProperty<T>(string propertyName, PropertyMetadata metadata) =>
            DependencyProperty.Register(propertyName, typeof(T), typeof(LottiePlayer), metadata);

        static DependencyProperty RegisterDependencyProperty<T>(string propertyName, T defaultValue) =>
            DependencyProperty.Register(propertyName, typeof(T), typeof(LottiePlayer), new PropertyMetadata(defaultValue));

        static DependencyProperty RegisterDependencyProperty<T>(string propertyName, T defaultValue, Action<LottiePlayer, T> callback) =>
            DependencyProperty.Register(propertyName, typeof(T), typeof(LottiePlayer),
                new PropertyMetadata(defaultValue, (d, e) => callback(((LottiePlayer)d), (T)e.NewValue)));
        #endregion DependencyProperty helpers

        StateCapture CaptureState() => new StateCapture(this);

        sealed class StateCapture
        {
            readonly LottiePlayer _owner;
            readonly int _capturedState;

            internal StateCapture(LottiePlayer owner)
            {
                _owner = owner;
                _capturedState = owner._stateTransitionCounter;
            }

            internal bool HasChanged => _owner._stateTransitionCounter != _capturedState;
        }
    }
}
