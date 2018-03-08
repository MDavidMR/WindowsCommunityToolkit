namespace Lottie.Data
{
    public sealed class PathShape : ShapeLayerContent
    {
        public PathShape(
            string name,
            AnimatableValue<PathGeometry> geometry)
            : base(name)
        {
            PathData = geometry;
        }

        public AnimatableValue<PathGeometry> PathData { get; }

        public override ShapeContentType ContentType => ShapeContentType.Path;
    }
}

