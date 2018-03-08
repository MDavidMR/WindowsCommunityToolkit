namespace Lottie.Data
{
    public sealed class TextLayer : Layer
    {
        public TextLayer(
            string name,
            int layerId,
            int? parentId,
            string refId,
            AnimatableTransform transform,
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

        }
        public override LayerType Type => LayerType.Text;
    }
}
