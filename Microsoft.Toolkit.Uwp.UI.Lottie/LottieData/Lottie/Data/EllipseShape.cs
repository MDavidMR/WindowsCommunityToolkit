namespace Lottie.Data
{
    public sealed class EllipseShape : ShapeLayerContent
    {
        public EllipseShape(
            string name,
            AnimatableVector2 position,
            AnimatableVector2 size)
            : base(name)
        {
            Position = position;
            Size = size;
        }

        public AnimatableVector2 Position { get; }

        public AnimatableVector2 Size { get; }

        public override ShapeContentType ContentType => ShapeContentType.Ellipse;
    }
}