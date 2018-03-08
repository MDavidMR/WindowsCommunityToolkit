using System.Numerics;

namespace Lottie.Data
{
    public sealed class BezierSegment
    {
        public BezierSegment(Vector2 cp1, Vector2 cp2, Vector2 vertex)
        {
            ControlPoint1 = cp1;
            ControlPoint2 = cp2;
            Vertex = vertex;
        }

        public Vector2 ControlPoint1 { get; }
        public Vector2 ControlPoint2 { get; }
        public Vector2 Vertex { get; }
    }
}
