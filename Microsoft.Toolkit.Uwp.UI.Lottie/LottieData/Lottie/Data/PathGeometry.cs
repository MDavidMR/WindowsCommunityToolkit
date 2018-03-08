using System.Collections.Generic;
using System.Numerics;

namespace Lottie.Data
{
    public sealed class PathGeometry
    {

        public PathGeometry(
            Vector2 start,
            IEnumerable<BezierSegment> beziers,
            bool isClosed,
            FillRule fillRule)
        {
            Start = start;
            Beziers = beziers;
            IsClosed = isClosed;
            FillRule = fillRule;
        }

        public Vector2 Start { get; }
        public IEnumerable<BezierSegment> Beziers { get; }
        public bool IsClosed { get; }
        public FillRule FillRule { get; }
    }
}
