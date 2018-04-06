namespace LottieData
{
#if !WINDOWS_UWP
    public
#endif
    sealed class ImageLayer : Layer
    {
        public ImageLayer(
            string name,
            int layerId,
            int? parentId,
            bool isHidden,
            Transform transform,
            double timeStretch,
            double startFrame,
            double inFrame, 
            double outFrame,
            BlendMode blendMode,
            bool is3d,
            bool autoOrient,
            string refId)
            : base(
                 name,
                 layerId,
                 parentId,
                 isHidden,
                 transform,
                 timeStretch,
                 startFrame,
                 inFrame,
                 outFrame,
                 blendMode,
                 is3d,
                 autoOrient)
        {
            RefId = refId;
        }

        /// <summary>
        /// The id of an <see cref="Asset"/> referenced by this layer.
        /// </summary>
        public string RefId { get; }

        public override LayerType Type => LayerType.Image;
    }
}
