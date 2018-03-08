using System.Collections.Generic;

namespace Lottie.Data
{
    public sealed class ShapeStroke : ShapeLayerContent
    {
        /// <summary>
        /// Shape Stroke member of a Shape Layer.
        /// </summary>
        public ShapeStroke(
            string name,
            AnimatableValue<float> offset,
            IEnumerable<float> dashPattern,
            AnimatableValue<Color> color,
            AnimatableValue<float> opacity,
            AnimatableValue<float> thickness,
            LineCapType capType,
            LineJoinType joinType,
            float miterLimit)
            : base(name)
        {
            DashOffset = offset;
            DashPattern = dashPattern;
            Color = color;
            Opacity = opacity;
            Thickness = thickness;
            CapType = capType;
            JoinType = joinType;
            MiterLimit = miterLimit;
        }

        public AnimatableValue<Color> Color { get; }

        internal AnimatableValue<float> Opacity { get; }

        public AnimatableValue<float> Thickness { get; }

        public IEnumerable<float> DashPattern { get; }

        public AnimatableValue<float> DashOffset { get; }

        public LineCapType CapType { get; }

        public LineJoinType JoinType { get; }

        public float MiterLimit { get; }

        public override ShapeContentType ContentType => ShapeContentType.SolidColorStroke;


        public enum LineCapType
        {
            // NOTE: must be kept in sync with JSON
            Butt = 0,
            Round = 1,
            Unknown = 2,
        }

        public enum LineJoinType
        {
            // NOTE: must be kept in sync with JSON
            Miter = 0,
            Round = 1,
            Bevel = 2,
        }
    }
}