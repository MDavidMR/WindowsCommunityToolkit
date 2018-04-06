﻿namespace LottieData
{
#if !WINDOWS_UWP
    public
#endif
    sealed class SolidLayer : Layer
    {
        public SolidLayer(
            string name,
            int layerId,
            int? parentId,
            bool isHidden,
            Transform transform,
            int width,
            int height,
            Color color,
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
