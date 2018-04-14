using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.Composition;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Hosting;
using Windows.UI.Xaml.Media;

namespace Lottie
{
    /// <summary>
    /// A XAML element that displays and controls an animated composition.
    /// </summary>
    public sealed class CompositionPlayer : FrameworkElement
    {
        // The Visual to which the current composition will be attached.
        readonly ContainerVisual _rootVisual;

        // Commands (Pause/Play/Resume/Stop) that were requested before
        // the VisualPlayer was fully loaded. These will be played back
        // when the load completes.
        readonly List<Command> _commands = new List<Command>();

        // Set true when a play/resume/stop/pause request is made
        // for a new Source. This is used to control the AutoPlay
        // behavior, which, when set, will initiate a play if there
        // have been no explicit requests yet.
        bool _requestSeen;

        // The current Lottie composition translated to a WinComp visual.
        VisualPlayer _visualPlayer;

        #region Dependency properties
        public static DependencyProperty AutoPlayProperty { get; } =
            RegisterDP(nameof(AutoPlay), false,
                (owner, oldValue, newValue) => owner.HandleAutoPlayPropertyChanged(oldValue, newValue));

        public static DependencyProperty DiagnosticsProperty { get; } =
            RegisterDP(nameof(Diagnostics), (object)null);

        public static DependencyProperty DurationProperty { get; } =
            RegisterDP(nameof(Duration), TimeSpan.Zero);

        public static DependencyProperty FromProgressProperty { get; } =
            RegisterDP(nameof(FromProgress), 0.0);

        public static DependencyProperty IsCompositionLoadedProperty { get; } =
            RegisterDP(nameof(IsCompositionLoaded), false);

        public static DependencyProperty IsPlayingProperty { get; } =
            RegisterDP(nameof(IsPlaying), false);

        public static DependencyProperty LoopAnimationProperty { get; } =
            RegisterDP(nameof(LoopAnimation), true);

        public static DependencyProperty ReverseAnimationProperty { get; } =
            RegisterDP(nameof(ReverseAnimation), false);

        public static DependencyProperty SourceProperty { get; } =
            RegisterDP(nameof(Source), (CompositionPlayerSource)null,
                (owner, oldValue, newValue) => owner.HandleSourcePropertyChanged(oldValue, newValue));

        public static DependencyProperty StretchProperty { get; } =
            RegisterDP(nameof(Stretch), Stretch.Uniform,
            (owner, oldValue, newValue) => owner.HandleStretchPropertyChanged(oldValue, newValue));

        public static DependencyProperty ToProgressProperty { get; } =
            RegisterDP(nameof(ToProgress), 1.0);

        #endregion Dependency properties

        public CompositionPlayer()
        {
            // Create a visual to parent the content.
            var compositor = Window.Current.Compositor;
            _rootVisual = compositor.CreateContainerVisual();
            ElementCompositionPreview.SetElementChildVisual(this, _rootVisual);

            // Ensure the content can't render outside the bounds of the element.
            _rootVisual.Clip = compositor.CreateInsetClip();
        }

        #region Properties
        public bool AutoPlay
        {
            get => (bool)GetValue(AutoPlayProperty);
            set => SetValue(AutoPlayProperty, value);
        }

        /// <summary>
        /// Contains optional diagnostics information about the composition.
        /// </summary>
        public object Diagnostics => GetValue(DiagnosticsProperty);

        public TimeSpan Duration => (TimeSpan)GetValue(DurationProperty);

        /// <summary>
        /// The point at which to start the animation, as a value from 0 to 1.
        /// </summary>
        public double FromProgress
        {
            get => (double)GetValue(FromProgressProperty);
            set => SetValue(FromProgressProperty, value);
        }

        public bool IsCompositionLoaded => (bool)GetValue(IsCompositionLoadedProperty);

        public bool IsPlaying => (bool)GetValue(IsPlayingProperty);

        /// <summary>
        /// If true, the animation will loop continuously between <see cref="FromProgress"/>
        /// and <see cref="ToProgress"/>. If false, the animation will play once each
        /// time the <see cref="PlayAsync"/> method is called, or when the <see cref="Source"/>
        /// property is set and the <see cref="AutoPlay"/> property is true.
        /// </summary>
        public bool LoopAnimation
        {
            get => (bool)GetValue(LoopAnimationProperty);
            set => SetValue(LoopAnimationProperty, value);
        }

        /// <summary>
        /// If true, the animation will play backwards, from <see cref="ToProgress"/> to <see cref="FromProgress"/>.
        /// </summary>
        public bool ReverseAnimation
        {
            get => (bool)GetValue(ReverseAnimationProperty);
            set => SetValue(ReverseAnimationProperty, value);
        }

        public CompositionPlayerSource Source
        {
            get => (CompositionPlayerSource)GetValue(SourceProperty);
            set => SetValue(SourceProperty, value);
        }

        public Stretch Stretch
        {
            get => (Stretch)GetValue(StretchProperty);
            set => SetValue(StretchProperty, value);
        }

        /// <summary>
        /// The point at which to finish the animation, as a value from 0 to 1.
        /// </summary>
        public double ToProgress
        {
            get => (double)GetValue(ToProgressProperty);
            set => SetValue(ToProgressProperty, value);
        }

        #endregion Properties

        public IAsyncAction PlayAsync() => _PlayAsync().AsAsyncAction();

        public async void Play() => await _PlayAsync();

        public void SetProgress(double progress)
        {
            if (_visualPlayer == null)
            {
                _commands.Add(new SetProgressCommand(progress));
            }
            else
            {
                _requestSeen = true;
                _visualPlayer.Pause();
                _visualPlayer.SetProgress(progress);
            }

            Pause();
            // Set the value, either directly or as a command.
        }

        public void Stop()
        {
            if (_visualPlayer == null)
            {
                _commands.Add(Command.Stop);
            }
            else
            {
                _requestSeen = true;
                _visualPlayer.Stop();
            }
        }

        public void Pause()
        {
            if (_visualPlayer == null)
            {
                _commands.Add(Command.Pause);
            }
            else
            {
                _requestSeen = true;
                _visualPlayer.Pause();
            }
        }

        public void Resume()
        {
            if (_visualPlayer == null)
            {
                _commands.Add(Command.Resume);
            }
            else
            {
                _requestSeen = true;
                _visualPlayer.Resume();
            }
        }

        // Requests that the animation starts playing and returns a Task
        // that completes when the animation completes.
        Task _PlayAsync()
        {
            if (_visualPlayer == null)
            {
                return EnqueuePlayAsync(FromProgress, ToProgress, LoopAnimation, ReverseAnimation);
            }
            else
            {
                _requestSeen = true;
                return _visualPlayer.PlayAsync(FromProgress, ToProgress, LoopAnimation, ReverseAnimation);
            }
        }

        Task EnqueuePlayAsync(double fromProgress, double toProgress, bool loopAnimation, bool reverseAnimation)
        {
            Debug.Assert(_visualPlayer == null);
            var playCommand = new PlayAsyncCommand(fromProgress, toProgress, loopAnimation, reverseAnimation);
            _commands.Add(playCommand);
            return playCommand.Task;
        }

        // Converts infinity to double.MaxValue so as to avoid needing special handling for infinite values.
        static double AbstractInfinity(double value) => double.IsInfinity(value) ? double.MaxValue : value;

        protected override Size MeasureOverride(Size availableSize)
        {
            Debug.WriteLine($"Measure availableSize: {availableSize} Stretch: {Stretch}");

            Size measuredSize;

            // No Width or Height are specified.
            if (_visualPlayer == null || _visualPlayer.Size.ToSize().IsEmpty)
            {
                // No VisualPlayer is loaded or it has a 0 size, so it will take up no space.
                // It's not valid to return Size.Empty (it will cause a div/0 in the caller),
                // so return the smallest possible size.
                measuredSize = new Size(double.Epsilon, double.Epsilon);
            }
            else
            {
                // Measure the size based on the stretch mode.
                switch (Stretch)
                {
                    case Stretch.None:
                        {
                            if (_visualPlayer.Size.X < AbstractInfinity(availableSize.Width) && _visualPlayer.Size.Y < AbstractInfinity(availableSize.Height))
                            {
                                // The native size of the _visualPlayer will fit inside the available size.
                                measuredSize = _visualPlayer.Size.ToSize();
                            }
                            else if (double.IsInfinity(availableSize.Width))
                            {
                                // The native size won't fit, and width is infinite
                                if (double.IsInfinity(availableSize.Height))
                                {
                                    // The width and height are infinite.
                                    measuredSize = availableSize;
                                }
                                else
                                {
                                    // Just the width is infinite. The native height fits.
                                    measuredSize = new Size(_visualPlayer.Size.X, availableSize.Height);
                                }
                            }
                            else if (double.IsInfinity(availableSize.Height))
                            {
                                // Just the height is infinite. The native width fits.
                                measuredSize = new Size(availableSize.Width, _visualPlayer.Size.Y);
                            }
                            else
                            {
                                // The native size is too big and no available dimension is infinite.
                                measuredSize = availableSize;
                            }
                        }
                        break;
                    case Stretch.Fill:
                        if (double.IsInfinity(availableSize.Width) || double.IsInfinity(availableSize.Height))
                        {
                            // One of the dimensions is infinite so we can't fill both dimensions. Fall back
                            // to Uniform so at least the non-infinite dimension will be filled.
                            goto case Stretch.Uniform;
                        }
                        else
                        {
                            // We will fill all available space.
                            measuredSize = availableSize;
                        }
                        break;
                    case Stretch.UniformToFill:
                        if (double.IsInfinity(availableSize.Width) || double.IsInfinity(availableSize.Height))
                        {
                            // One of the dimensions is infinite, we can't scale in such a way as to leave
                            // no space around the edge, so fall back to Uniform.
                            goto case Stretch.Uniform;
                        }
                        else
                        {
                            // Scale so there is no space around the edge.
                            var widthScale = availableSize.Width / _visualPlayer.Size.X;
                            var heightScale = availableSize.Height / _visualPlayer.Size.Y;
                            if (widthScale < heightScale)
                            {
                                heightScale = widthScale;
                            }
                            else
                            {
                                widthScale = heightScale;
                            }
                            var measuredX = Math.Min(_visualPlayer.Size.X * widthScale, availableSize.Width);
                            var measuredY = Math.Min(_visualPlayer.Size.Y * heightScale, availableSize.Height);

                            measuredSize = new Size(measuredX, measuredY);
                        }
                        break;
                    case Stretch.Uniform:
                        {
                            // Scale so that one dimension fits exactly and no dimension exceeds the boundary.
                            var widthScale = AbstractInfinity(availableSize.Width) / _visualPlayer.Size.X;
                            var heightScale = AbstractInfinity(availableSize.Height) / _visualPlayer.Size.Y;
                            measuredSize = (heightScale > widthScale)
                                ? new Size(availableSize.Width, _visualPlayer.Size.Y * widthScale)
                                : new Size(_visualPlayer.Size.X * heightScale, availableSize.Height);
                        }
                        break;
                    default:
                        throw new InvalidOperationException();
                }
            }

            Debug.WriteLine($"Measure returning: {measuredSize}");
            return measuredSize;
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            Debug.WriteLine($"Arrange finalSize: {finalSize} Stretch: {Stretch}");

            if (_visualPlayer == null)
            {
                // No content, nothing to do.
                return finalSize;
            }

            var widthScale = 1.0;
            var heightScale = 1.0;

            // Now that we know how much size we have to fill, set the scaling and offset appropriately.
            switch (Stretch)
            {
                case Stretch.None:
                    // Do not scale, do not center.
                    break;
                case Stretch.Fill:
                    widthScale = finalSize.Width / _visualPlayer.Size.X;
                    heightScale = finalSize.Height / _visualPlayer.Size.Y;
                    break;
                case Stretch.Uniform:
                    {
                        widthScale = finalSize.Width / _visualPlayer.Size.X;
                        heightScale = finalSize.Height / _visualPlayer.Size.Y;
                        if (widthScale < heightScale)
                        {
                            heightScale = widthScale;
                        }
                        else
                        {
                            widthScale = heightScale;
                        }
                    }
                    break;
                case Stretch.UniformToFill:
                    {

                        widthScale = finalSize.Width / _visualPlayer.Size.X;
                        heightScale = finalSize.Height / _visualPlayer.Size.Y;
                        if (widthScale > heightScale)
                        {
                            heightScale = widthScale;
                        }
                        else
                        {
                            widthScale = heightScale;
                        }
                    }
                    break;
                default:
                    throw new InvalidOperationException();
            }
            // Scale appropriately.
            _rootVisual.Scale = new Vector3((float)widthScale, (float)heightScale, 1);

            var xOffset = 0.0;
            var yOffset = 0.0;

            // A size needs to be set because there's an InsetClip applied, and without a size it will clip everything.
            var scaledWidth = _visualPlayer.Size.X * widthScale;
            var scaledHeight = _visualPlayer.Size.Y * heightScale;
            _rootVisual.Size = new Vector2((float)Math.Min(finalSize.Width / widthScale, _visualPlayer.Size.X), (float)Math.Min(finalSize.Height / heightScale, _visualPlayer.Size.Y));

            // Center the animation.
            if (Stretch != Stretch.None)
            {
                xOffset = (finalSize.Width - scaledWidth) / 2;
                yOffset = (finalSize.Height - scaledHeight) / 2;
                _rootVisual.Offset = new Vector3((float)xOffset, (float)yOffset, 0);

                if (Stretch == Stretch.UniformToFill)
                {
                    // Adjust the position of the clip.
                    _rootVisual.Clip.Offset = new Vector2((float)(-xOffset / widthScale), (float)(-yOffset / heightScale));
                } else
                {
                    _rootVisual.Clip.Offset = Vector2.Zero;
                }
            }

            Debug.WriteLine($"Arrange: final {finalSize} scale: {widthScale}x{heightScale}  offset: {xOffset},{yOffset} clip size: {_rootVisual.Size}");
            return finalSize;
        }

        // Called when the AutoPlay property is updated.
        void HandleAutoPlayPropertyChanged(bool oldValue, bool newValue)
        {
            if (newValue)
            {
                if (_visualPlayer == null)
                {
                    _commands.Add(Command.AutoPlay);
                }
                else
                {
                    if (!_requestSeen)
                    {
                        Play();
                    }
                }
            }
            else
            {
                // Ensure there are no auto-play commands enqueued.
                while (_commands.Remove(Command.AutoPlay)) { }
            }
        }

        // Called when the Source property is updated.
        void HandleSourcePropertyChanged(CompositionPlayerSource oldValue, CompositionPlayerSource newValue)
        {
            // Clear out the command queue. Any commands that were
            // enqueued before the Source was set are irrelevant.
            foreach (var command in _commands)
            {
                if (command.Type == Command.CommandType.PlayAsync)
                {
                    // Complete the PlayAsync task.
                    ((PlayAsyncCommand)command).CompleteTask();
                }
            }
            _commands.Clear();

            if (newValue == null)
            {
                UnloadVisualPlayer();
                SetValue(IsCompositionLoadedProperty, false);
            }
            else
            {
                if (AutoPlay)
                {
                    // Auto-play is enabled. Enqueue an AutoPlay command.
                    _commands.Add(Command.AutoPlay);
                }
                LoadVisualPlayer(newValue);
                SetValue(IsCompositionLoadedProperty, true);
            }
        }

        // Called when the Stretch property is updated.
        void HandleStretchPropertyChanged(Stretch oldValue, Stretch newValue)
        {
            if (_visualPlayer != null)
            {
                InvalidateMeasure();
            }
        }

        async void LoadVisualPlayer(CompositionPlayerSource source)
        {
            // Unloading will ensure that any new play/pause/resume/stop requests will be enqueued.
            UnloadVisualPlayer();

            // Attempt to load the VisualPlayer from the source.
            var loadResult = await source.TryLoad(Window.Current.Compositor);

            if (loadResult.LoadSucceeded)
            {
                _visualPlayer = loadResult.VisualPlayer;

                Debug.Assert(_rootVisual.Children.Count == 0);

                _rootVisual.Children.InsertAtTop(_visualPlayer.Root);

                // The element needs to be measured again for the new content.
                InvalidateMeasure();

                // Play back any commands that were enqueued during loading.
                if (_commands.Where(cmd => cmd.Type == Command.CommandType.AutoPlay).Any() &&
                    !_commands.Where(cmd => cmd.Type != Command.CommandType.AutoPlay).Any())
                {
                    // AutoPlay was enabled when loading was enabled or since loading started,
                    // AND there were no other requests. Auto-play.
                    Play();
                }
                else
                {
                    foreach (var command in _commands)
                    {
                        switch (command.Type)
                        {
                            case Command.CommandType.PlayAsync:
                                {
                                    // Hook up the TaskCompletionSource to complete the 
                                    // original play request when _PlayAsync completes.
                                    var playCommand = (PlayAsyncCommand)command;
                                    _visualPlayer.PlayAsync(playCommand.FromProgress, playCommand.ToProgress, playCommand.Loop, playCommand.Reverse).
                                        GetAwaiter().
                                            OnCompleted(playCommand.CompleteTask);
                                }
                                break;
                            case Command.CommandType.Pause:
                                Pause();
                                break;
                            case Command.CommandType.Resume:
                                Resume();
                                break;
                            case Command.CommandType.Stop:
                                Stop();
                                break;
                            case Command.CommandType.SetProgress:
                                Pause();
                                SetProgress(((SetProgressCommand)command).Progress);
                                break;
                            case Command.CommandType.AutoPlay:
                                // Ignore auto-play - it is handled above.
                                break;
                            default:
                                throw new InvalidOperationException();
                        }
                    }
                }
                // All command have been processed.
                _commands.Clear();

                SetValue(DurationProperty, _visualPlayer.AnimationDuration);
                SetValue(DiagnosticsProperty, loadResult.Diagnostics);
            }
        }

        void UnloadVisualPlayer()
        {
            if (_visualPlayer != null)
            {
                _rootVisual.Children.RemoveAll();

                // TODO - also call dispose when this control is unloaded.
                _visualPlayer.Dispose();
                _visualPlayer = null;

                SetValue(DurationProperty, null);
                SetValue(DiagnosticsProperty, null);
            }
        }

        #region DependencyProperty helpers

        static DependencyProperty RegisterDP<T>(string propertyName, T defaultValue) =>
            DependencyProperty.Register(propertyName, typeof(T), typeof(CompositionPlayer), new PropertyMetadata(defaultValue));

        static DependencyProperty RegisterDP<T>(string propertyName, T defaultValue, Action<CompositionPlayer, T, T> callback) =>
            DependencyProperty.Register(propertyName, typeof(T), typeof(CompositionPlayer),
                new PropertyMetadata(defaultValue, (d, e) => callback(((CompositionPlayer)d), (T)e.OldValue, (T)e.NewValue)));

        #endregion DependencyProperty helpers

        class Command
        {
            protected Command(CommandType type) => Type = type;

            internal static readonly Command Pause = new Command(CommandType.Pause);
            internal static readonly Command Resume = new Command(CommandType.Resume);
            internal static readonly Command Stop = new Command(CommandType.Stop);
            internal static readonly Command AutoPlay = new Command(CommandType.AutoPlay);
            internal CommandType Type { get; }

            internal enum CommandType
            {
                AutoPlay,
                PlayAsync,
                Pause,
                Resume,
                Stop,
                SetProgress,
            }
        }

        sealed class PlayAsyncCommand : Command
        {
            readonly TaskCompletionSource<bool> _taskCompletionSource
                = new TaskCompletionSource<bool>();

            internal PlayAsyncCommand(double fromProgress, double toProgress, bool loop, bool reverse) : base(CommandType.PlayAsync)
            {
                FromProgress = fromProgress;
                ToProgress = toProgress;
                Loop = loop;
                Reverse = reverse;
            }
            internal double FromProgress { get; }
            internal double ToProgress { get; }
            internal bool Loop { get; }
            internal bool Reverse { get; }

            internal void CompleteTask() => _taskCompletionSource.SetResult(true);

            // Gets a Task that will complete when the PlayCommand is completed.
            internal Task Task => _taskCompletionSource.Task;

        }

        sealed class SetProgressCommand : Command
        {
            internal SetProgressCommand(double progress) : base(CommandType.SetProgress)
            {
                Progress = progress;
            }
            internal double Progress { get; }
        }
    }
}
