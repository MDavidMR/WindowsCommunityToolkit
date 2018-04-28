using WinCompData.Mgc;
using WinCompData.Sn;
using WinCompData.Wg;

namespace WinCompData.Mgcg
{
#if !WINDOWS_UWP
    public
#endif
    abstract class CanvasGeometry : IGeometrySource2D
    {
        CanvasGeometry() { }

        public enum GeometryType
        {
            Combination,
            Ellipse,
            Path,
            RoundedRectangle,
        }

        public static CanvasGeometry CreatePath(CanvasPathBuilder pathBuilder)
            => new Path
            {
                PathBuilder = pathBuilder
            };

        public static CanvasGeometry CreateRoundedRectangle(CanvasDevice device, float x, float y, float w, float h, float radiusX, float radiusY)
            => new RoundedRectangle
            {
                X = x,
                Y = y,
                W = w,
                H = h,
                RadiusX = radiusX,
                RadiusY = radiusY
            };

        public static CanvasGeometry CreateEllipse(CanvasDevice device, float x, float y, float radiusX, float radiusY)
            => new Ellipse
            {
                X = x,
                Y = y,
                RadiusX = radiusX,
                RadiusY = radiusY
            };

        public CanvasGeometry CombineWith(CanvasGeometry other, Matrix3x2 matrix, CanvasGeometryCombine combineMode)
         => new Combination
         {
             A = this,
             B = other,
             Matrix = matrix,
             CombineMode = combineMode
         };


        public abstract GeometryType Type { get; }

        public sealed class Combination : CanvasGeometry
        {
            public CanvasGeometry A { get; internal set; }
            public CanvasGeometry B { get; internal set; }
            public Matrix3x2 Matrix { get; internal set; }
            public CanvasGeometryCombine CombineMode { get; internal set; }
            public override GeometryType Type => GeometryType.Combination;
        }

        public sealed class Ellipse : CanvasGeometry
        {
            internal Ellipse() { }
            public float X { get; internal set; }
            public float Y { get; internal set; }
            public float RadiusX { get; internal set; }
            public float RadiusY { get; internal set; }

            public override GeometryType Type => GeometryType.Ellipse;
        }

        public sealed class Path : CanvasGeometry
        {
            public CanvasPathBuilder PathBuilder { get; internal set; }

            public override GeometryType Type => GeometryType.Path;
        }

        public sealed class RoundedRectangle : CanvasGeometry
        {
            public float X { get; internal set; }
            public float Y { get; internal set; }
            public float W { get; internal set; }
            public float H { get; internal set; }
            public float RadiusX { get; internal set; }
            public float RadiusY { get; internal set; }
            public override GeometryType Type => GeometryType.RoundedRectangle;
        }
    }
}
