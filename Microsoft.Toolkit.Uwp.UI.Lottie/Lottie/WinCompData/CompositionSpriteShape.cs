using System.Collections.Generic;

namespace WinCompData
{
#if !WINDOWS_UWP
    public
#endif
    sealed class CompositionSpriteShape : CompositionShape
    {
        internal CompositionSpriteShape() { }

        public override ConcreteClassType Type => ConcreteClassType.CompositionSpriteShape;
        public CompositionStrokeCap StrokeDashCap { get; set; } = CompositionStrokeCap.Flat;
        public CompositionBrush StrokeBrush { get; set; }
        public bool IsStrokeNonScaling { get; set; }
        public CompositionGeometry Geometry { get; set; }
        public CompositionBrush FillBrush { get; set; }
        public float StrokeThickness { get; set; } = 1;
        public CompositionStrokeCap StrokeStartCap { get; set; } = CompositionStrokeCap.Flat;
        public float StrokeMiterLimit { get; set; } = 1;
        public CompositionStrokeLineJoin StrokeLineJoin { get; set; } = CompositionStrokeLineJoin.Miter;
        public CompositionStrokeCap StrokeEndCap { get; set; } = CompositionStrokeCap.Flat;
        public float StrokeDashOffset { get; set; }
        public List<float> StrokeDashArray { get; } = new List<float>();
    }
}
