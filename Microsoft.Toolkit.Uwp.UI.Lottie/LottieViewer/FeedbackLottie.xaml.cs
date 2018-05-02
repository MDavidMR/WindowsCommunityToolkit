using Lottie;
using System;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace LottieViewer
{
    public sealed partial class FeedbackLottie : UserControl
    {
        // Shrinks from the expanded JSON file back to the initial size.
        static readonly CompositionSegment ShrinkToInitial =
            new CompositionSegment(0.1608, 0.203, loopAnimation: false, reverseAnimation: true);

        // Expands from the initial state to a large JSON file.
        static readonly CompositionSegment ExpandFromInitial = new CompositionSegment(0.1608, 0.203);

        // A loop where the JSON file looks excited about being dropped.
        static readonly CompositionSegment ExcitedDropLoop = 
            new CompositionSegment(0.203, 0.603, loopAnimation:true, reverseAnimation: false);

        // Follows on from ExcitedDropLoop.
        static readonly CompositionSegment ExcitedResolution = new CompositionSegment(0.603, 0.791);

        // The explosion at the end of loading.
        static readonly CompositionSegment FinishLoading = new CompositionSegment(0.709, 0.791);


        Task _currentPlay = Task.CompletedTask;
        DragNDropHintState _dragNDropHintState = DragNDropHintState.Initial;

        public FeedbackLottie()
        {
            this.InitializeComponent();
        }


        internal void PlayInitialStateAnimation()
        {
            _dragNDropHintState = DragNDropHintState.Initial;
            _dragNDropHint.SetProgress(0);
        }

        internal async void PlayDragEnterAnimation()
        {
            if (_dragNDropHintState == DragNDropHintState.Initial
                || _dragNDropHintState == DragNDropHintState.Shrinking)
            {
                _dragNDropHintState = DragNDropHintState.Encouraging;
                await PlaySegment(ExpandFromInitial);
                await PlaySegment(ExcitedDropLoop);
            }
        }

        internal Task PlayDroppedAnimation()
        {
            if (_dragNDropHintState == DragNDropHintState.Encouraging)
            {
                _dragNDropHintState = DragNDropHintState.Finished;
                return PlaySegment(ExcitedResolution);
            }
            else
            {
                _dragNDropHintState = DragNDropHintState.Finished;
                return PlaySegment(FinishLoading);
            }
        }

        internal void PlayDragLeaveAnimation()
        {
            if (_dragNDropHintState == DragNDropHintState.Encouraging)
            {
                _dragNDropHintState = DragNDropHintState.Shrinking;
                PlaySegment(ShrinkToInitial);
            }
        }

        Task PlaySegment(CompositionSegment segment)
        {
            return _currentPlay = _dragNDropHint.PlayAsync(segment).AsTask();
        }

        enum DragNDropHintState
        {
            Disabled,
            Initial,
            Encouraging,
            Finished,
            Shrinking,
        }

    }
}
