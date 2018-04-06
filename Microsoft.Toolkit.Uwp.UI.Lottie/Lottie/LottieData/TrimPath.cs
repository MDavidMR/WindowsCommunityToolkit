namespace LottieData
{
#if !WINDOWS_UWP
    public
#endif
    sealed class TrimPath : ShapeLayerContent
    {
        public TrimPath(
            string name,
            string matchName,
            TrimType trimPathType,
            Animatable<double> startPercent,
            Animatable<double> endPercent,
            Animatable<double> offsetDegrees) 
            : base(name, matchName)
        {
            TrimPathType = trimPathType;
            StartPercent = startPercent;
            EndPercent = endPercent;
            OffsetDegrees = offsetDegrees;
        }

        public Animatable<double> StartPercent { get; }

        public Animatable<double> EndPercent { get; }

        public Animatable<double> OffsetDegrees { get; }

        internal TrimType TrimPathType { get; }

        public override ShapeContentType ContentType => ShapeContentType.TrimPath;

        public enum TrimType
        {
            Simultaneously,
            Individually,
        }
    }
}
