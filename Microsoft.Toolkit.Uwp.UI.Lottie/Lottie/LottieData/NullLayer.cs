namespace LottieData
{
#if !WINDOWS_UWP
    public
#endif
    sealed class NullLayer : Layer
    {
        public NullLayer(
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
            bool autoOrient)
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
        }

        public override LayerType Type => LayerType.Null;

        public override LottieObjectType ObjectType => LottieObjectType.NullLayer;
    }
}
