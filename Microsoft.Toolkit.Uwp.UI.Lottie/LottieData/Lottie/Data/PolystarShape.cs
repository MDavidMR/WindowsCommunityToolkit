namespace Lottie.Data
{
    public sealed class PolystarShape : ShapeLayerContent
    {
        internal PolystarShape(
            LottieComposition owner,
            string name, 
            PolyStarType starType, 
            AnimatableValue<float> points, 
            AnimatableVector2 position, 
            AnimatableValue<float> rotation, 
            AnimatableValue<float> innerRadius, 
            AnimatableValue<float> outerRadius, 
            AnimatableValue<float> innerRoundedness, 
            AnimatableValue<float> outerRoundedness) 
            : base(name)
        {
            StarType = starType;
            Points = points;
            Position = position;
            Rotation = rotation;
            InnerRadius = innerRadius;
            OuterRadius = outerRadius;
            InnerRoundedness = innerRoundedness;
            OuterRoundedness = outerRoundedness;
        }

        internal PolyStarType StarType { get; }

        internal AnimatableValue<float> Points { get; }

        internal AnimatableVector2 Position { get; }

        internal AnimatableValue<float> Rotation { get; }

        internal AnimatableValue<float> InnerRadius { get; }

        internal AnimatableValue<float> OuterRadius { get; }

        internal AnimatableValue<float> InnerRoundedness { get; }

        internal AnimatableValue<float> OuterRoundedness { get; }

        public override ShapeContentType ContentType => ShapeContentType.Polystar;

        // TODO - this must be kep in sync with the JSON - remove the JSON dependency
        public enum PolyStarType
        {
            Star = 1,
            Polygon = 2
        }
    }
}
