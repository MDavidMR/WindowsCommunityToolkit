using System.Numerics;

namespace Lottie.Data
{
    public class CubicBezierEasing : Easing
    {
        public CubicBezierEasing(Vector2 controlPoint1, Vector2 controlPoint2)
        {
            ControlPoint1 = controlPoint1;
            ControlPoint2 = controlPoint2;
        }

        public Vector2 ControlPoint1 { get; }
        public Vector2 ControlPoint2 { get; }

        public override EasingType Type => EasingType.CubicBezier;
    }
}
