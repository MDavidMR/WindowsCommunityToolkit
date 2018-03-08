namespace Lottie.Data
{
    public sealed class TrimPath : ShapeLayerContent
    {
        public TrimPath(
            string name,
            TrimType trimPathType,
            AnimatableValue<float> start,
            AnimatableValue<float> end,
            AnimatableValue<float> offset) 
            : base(name)
        {
            TrimPathType = trimPathType;
            Start = start;
            End = end;
            Offset = offset;
        }

        public AnimatableValue<float> Start { get; }

        public AnimatableValue<float> End { get; }

        public AnimatableValue<float> Offset { get; }

        internal TrimType TrimPathType { get; }

        public override ShapeContentType ContentType => ShapeContentType.TrimPath;

        public enum TrimType
        {
            Simultaneously = 1,
            Individually = 2
        }
    }
}
