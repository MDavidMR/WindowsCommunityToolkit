using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Hosting;

namespace Lottie
{
    /// <summary>
    /// A XAML element that displays and controls an animated composition.
    /// </summary>
    public sealed class CompositionPlayer : FrameworkElement
    {
        // Commands (Pause/Play/Resume/Stop) that were requested before
        // the AnimatedComposition was fully loaded. These will be played back
        // when the load completes.
        readonly List<Command> _commands = new List<Command>();

        // Set true when a play/resume/stop/pause request is made
        // for a new Source. This is used to control the AutoPlay
        // behavior, which, when set, will initiate a play if there
        // have been no explicit requests yet.
        bool _requestSeen;

        // The current Lottie composition tranlated to a WinComp visual.
        AnimatedComposition _animatedComposition;

        // The size requested in the last Arrange pass.
        Vector2 _latestSize;

        public static DependencyProperty AutoPlayProperty { get; } =
            RegisterDP(nameof(AutoPlay), false,
                (owner, oldValue, newValue) => owner.HandleAutoPlayPropertyChanged(oldValue, newValue));

        public static DependencyProperty DiagnosticsProperty { get; } =
            RegisterDP(nameof(Diagnostics), (object)null);

        public static DependencyProperty DurationProperty { get; } =
            RegisterDP(nameof(Duration), (TimeSpan?)null);

        public static DependencyProperty IsCompositionLoadedProperty { get; } =
            RegisterDP(nameof(IsCompositionLoaded), false);

        public static DependencyProperty IsPlayingProperty { get; } =
            RegisterDP(nameof(IsPlaying), false);

        //// TODO - rename this to Position??
        public static DependencyProperty ProgressProperty { get; } =
            RegisterDP(nameof(Progress), 0.0,
                (owner, oldValue, newValue) => owner.HandleProgressPropertyChanged(oldValue, newValue));

        public static DependencyProperty SourceProperty { get; } =
            RegisterDP(nameof(Source), (CompositionPlayerSource)null,
                (owner, oldValue, newValue) => owner.HandleSourcePropertyChanged(oldValue, newValue));


        public bool AutoPlay
        {
            get => (bool)GetValue(AutoPlayProperty);
            set => SetValue(AutoPlayProperty, value);
        }

        public CompositionPlayerSource Source
        {
            get => (CompositionPlayerSource)GetValue(SourceProperty);
            set => SetValue(SourceProperty, value);
        }

        public bool IsCompositionLoaded => (bool)GetValue(IsCompositionLoadedProperty);

        public bool IsPlaying => (bool)GetValue(IsPlayingProperty);

        public IAsyncAction PlayAsync(bool loop) => _PlayAsync(loop).AsAsyncAction();

        public async void Play(bool loop) => await _PlayAsync(loop);

        public void Stop()
        {
            if (_animatedComposition == null)
            {
                _commands.Add(Command.Stop);
            }
            else
            {
                _requestSeen = true;
                _animatedComposition.Stop();
            }
        }

        public void Pause()
        {
            if (_animatedComposition == null)
            {
                _commands.Add(Command.Pause);
            }
            else
            {
                _requestSeen = true;
                _animatedComposition.Pause();
            }
        }

        public void Resume()
        {
            if (_animatedComposition == null)
            {
                _commands.Add(Command.Resume);
            }
            else
            {
                _requestSeen = true;
                _animatedComposition.Resume();
            }
        }


        public double Progress
        {
            get => (double)GetValue(ProgressProperty);
            set => SetValue(ProgressProperty, value);
        }

        /// <summary>
        /// Contains optional diagnostics information about the composition.
        /// </summary>
        public object Diagnostics => GetValue(DiagnosticsProperty);

        public TimeSpan? Duration => (TimeSpan?)GetValue(DurationProperty);

        protected override Size ArrangeOverride(Size finalSize)
        {
            _latestSize = finalSize.ToVector2();
            if (_animatedComposition != null)
            {
                _animatedComposition.Root.Size = _latestSize;
            }
            return finalSize;
        }

        // Requests that the animation starts playing and returns a Task
        // that completes when the animation completes.
        Task _PlayAsync(bool loop)
        {
            if (_animatedComposition == null)
            {
                return EnqueuePlayAsync(loop);
            }
            else
            {
                _requestSeen = true;
                return _animatedComposition.PlayAsync(loop);
            }
        }

        Task EnqueuePlayAsync(bool loop)
        {
            Debug.Assert(_animatedComposition == null);
            var playCommand = new PlayAsyncCommand(loop);
            _commands.Add(playCommand);
            return playCommand.Task;
        }

        // Called when the AutoPlay property is updated.
        void HandleAutoPlayPropertyChanged(bool oldValue, bool newValue)
        {
            if (newValue)
            {
                if (_animatedComposition == null)
                {
                    _commands.Add(Command.AutoPlay);
                }
                else
                {
                    if (!_requestSeen)
                    {
                        Play(loop: true);
                    }
                }
            }
            else
            {
                // Ensure there are no auto-play commands enqueued.
                while (_commands.Remove(Command.AutoPlay)) { }
            }
        }

        // Called when the Progress property is updated.
        void HandleProgressPropertyChanged(double oldValue, double newValue)
        {
            if (_animatedComposition != null)
            {
                // Pause first so it won't finish the current play.
                _animatedComposition.Pause();
                _animatedComposition.SetPosition(newValue);
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
                UnloadAnimatedComposition();
                SetValue(IsCompositionLoadedProperty, false);
            }
            else
            {
                if (AutoPlay)
                {
                    // Auto-play is enabled. Enqueue an AutoPlay command.
                    _commands.Add(Command.AutoPlay);
                }
                LoadAnimatedComposition(newValue);
                SetValue(IsCompositionLoadedProperty, true);
            }
        }

        async void LoadAnimatedComposition(CompositionPlayerSource source)
        {
            // Clearing this will ensure that any new play/pause/resume/stop requests will be enqueued.
            _animatedComposition = null;

            // Attempt to load the AnimatedComposition from the source.
            var loadResult = await source.TryLoad(Window.Current.Compositor);

            if (loadResult.LoadSucceeded)
            {
                _animatedComposition = loadResult.Composition;

                ElementCompositionPreview.SetElementChildVisual(this, _animatedComposition.Root);
                _animatedComposition.Root.Size = _latestSize;

                // Play back any commands that were enqueued during loading.
                if (_commands.Where(cmd => cmd.Type == Command.CommandType.AutoPlay).Any() &&
                    !_commands.Where(cmd => cmd.Type != Command.CommandType.AutoPlay).Any())
                {
                    // AutoPlay was enabled when loading was enabled or since loading started,
                    // AND there were no other requests. Auto-play.
                    Play(loop: true);
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
                                    _animatedComposition.PlayAsync(playCommand.Loop).
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

                SetValue(DurationProperty, _animatedComposition.AnimationDuration);
                SetValue(DiagnosticsProperty, loadResult.Diagnostics);
            }
        }

        void UnloadAnimatedComposition()
        {
            if (_animatedComposition != null)
            {
                ElementCompositionPreview.SetElementChildVisual(this, null);

                // TODO - also call dispose when this control is unloaded.
                _animatedComposition.Dispose();
                _animatedComposition = null;

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
            }
        }

        sealed class PlayAsyncCommand : Command
        {
            readonly TaskCompletionSource<bool> _taskCompletionSource
                = new TaskCompletionSource<bool>();

            internal PlayAsyncCommand(bool loop) : base(CommandType.PlayAsync)
            {
                Loop = loop;
            }

            internal bool Loop { get; }

            internal void CompleteTask() => _taskCompletionSource.SetResult(true);

            // Gets a Task that will complete when the PlayCommand is completed.
            internal Task Task => _taskCompletionSource.Task;

        }
    }
}
