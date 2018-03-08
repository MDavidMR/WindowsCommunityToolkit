namespace Lottie.Data
{
    public sealed class PreCompLayer : Layer
    {
        public PreCompLayer(
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
            // TODO - populate the layer in the precomp.
            //Layers = new LayerContainer();
        }

        public override LayerType Type => LayerType.PreComp;

        internal LayerContainer Layers { get; }

        // TODO: populate Height and Width.
        internal float Height { get; }
        internal float Width { get; }
    }
}
