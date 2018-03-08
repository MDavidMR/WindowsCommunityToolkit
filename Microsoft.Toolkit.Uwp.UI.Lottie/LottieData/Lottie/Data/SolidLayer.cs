namespace Lottie.Data
{
    public sealed class SolidLayer : Layer
    {
        public SolidLayer(
            string name,
            int layerId,
            int? parentId,
            string refId,
            AnimatableTransform transform,
            int width,
            int height,
            Color color,
            float timeStretch,
            float startProgress,
            float inFrame,
            float outFrame)
            : base(
             name,
             layerId,
             parentId,
             refId,
             transform,
             timeStretch,
             startProgress,
             inFrame,
             outFrame)
        {
            Color = color;
            Height = height;
            Width = width;
        }

        public Color Color { get; }

        public int Height { get; }

        public int Width { get; }

        public override LayerType Type => LayerType.Solid;

    }
}
