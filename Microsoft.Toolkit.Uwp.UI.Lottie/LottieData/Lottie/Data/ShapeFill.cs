namespace Lottie.Data
{
    public sealed class ShapeFill : ShapeLayerContent
    {
        readonly bool _fillEnabled;

        public ShapeFill(
            string name,
            bool fillEnabled,
            PathFillType fillType,
            AnimatableValue<Color> color,
            AnimatableValue<float> opacity) 
            : base(name)
        {
            _fillEnabled = fillEnabled; // TODO: Check with Hernan what this is for; appears to be something we can enable.
            FillType = fillType;
            Color = color;
            Opacity = opacity;
        }

        public AnimatableValue<Color> Color { get; }

        internal AnimatableValue<float> Opacity { get; }


        public PathFillType FillType { get; }

        public override ShapeContentType ContentType => ShapeContentType.SolidColorFill;

        public enum PathFillType
        {
            EvenOdd,
            InverseWinding,
            Winding
        }
    }
}
