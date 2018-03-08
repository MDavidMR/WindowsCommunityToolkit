namespace Lottie.Data
{
    public sealed class RectangleShape : ShapeLayerContent
    {
        public RectangleShape(
            string name, 
            AnimatableVector2 position, 
            AnimatableVector2 size, 
            AnimatableValue<float> cornerRadius) 
            : base(name)
        {
            Position = position;
            Size = size;
            CornerRadius = cornerRadius;
        }

        public AnimatableValue<float> CornerRadius { get; }

        public AnimatableVector2 Size { get; }

        public AnimatableVector2 Position { get; }

        public override ShapeContentType ContentType => ShapeContentType.Rectangle;
    }
}