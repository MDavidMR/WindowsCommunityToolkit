namespace Lottie.Data
{

    /// <summary>
    /// Describes a value at a particular point in time, and an optional easing function to
    /// interpolate to the next value.
    /// </summary>
    public sealed class KeyFrame<T>
    {
        // Some animations get exported with insane cp values in the tens of thousands.
        // PathInterpolator fails to create the interpolator in those cases and hangs.
        // Clamping the cp helps prevent that.
        const float MaxCPValue = 100;

        // TODO: frame should not be nullable

        public KeyFrame(T value, Easing easing, float? frame)
        {
            Value = value;
            Easing = easing;
            Frame = frame;
        }

        /// <summary>
        /// The value.
        /// </summary>
        public T Value { get; }
        /// <summary>
        /// The frame at which the animation should have the <see cref="Value"/>.
        /// </summary>
        public float? Frame { get; }
        public Easing Easing { get; }
    }
}