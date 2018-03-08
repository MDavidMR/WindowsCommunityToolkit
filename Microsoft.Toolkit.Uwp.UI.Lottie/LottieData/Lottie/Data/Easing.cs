namespace Lottie.Data
{
    public abstract class Easing
    {
        internal Easing() { }

        public abstract EasingType Type { get; }

        public enum EasingType
        {
            Linear,
            CubicBezier,
        }
    }
}
