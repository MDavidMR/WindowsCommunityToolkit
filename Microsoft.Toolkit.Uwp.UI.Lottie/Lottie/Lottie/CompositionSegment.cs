namespace Lottie
{
    /// <summary>
    /// Defines a segment of a composition that can be played by the <see cref="CompositionPlayer"/>.
    /// </summary>
    public sealed class CompositionSegment
    {
        public double FromProgress { get; }
        public double ToProgress { get; }
        public bool LoopAnimation { get; }
        public bool ReverseAnimation { get; }

        public CompositionSegment(double fromProgress, double toProgress, bool loopAnimation, bool reverseAnimation)
        {
            FromProgress = fromProgress;
            ToProgress = toProgress;
            LoopAnimation = loopAnimation;
            ReverseAnimation = reverseAnimation;
        }

        /// <summary>
        /// Defines a segment that plays from <paramref name="fromProgress"/> to <paramref name="toProgress"/>
        /// without looping or repeating.
        /// </summary>
        public CompositionSegment(double fromProgress, double toProgress)
            : this(fromProgress, toProgress, loopAnimation: false, reverseAnimation: false)
        {
        }
    }
}
