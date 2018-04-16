using WinCompData.Mgc;
using WinCompData.Sn;
using WinCompData.Wg;

namespace WinCompData.Mgcg
{
#if !WINDOWS_UWP
    public
#endif
    sealed class CanvasGeometry : IGeometrySource2D
    {
        CanvasGeometry(GeometryType type, object state)
        {
            Type = type;
            Content = state;
        }

        public enum GeometryType
        {
            Combination,
            Ellipse,
            Path,
            RoundedRectangle,
        }

        public static CanvasGeometry CreatePath(CanvasPathBuilder pathBuilder)
        {
            return new CanvasGeometry(GeometryType.Path, pathBuilder);
        }

        public static CanvasGeometry CreateRoundedRectangle(CanvasDevice device, float x, float y, float w, float h, float radiusX, float radiusY)
        {
            return new CanvasGeometry(
                GeometryType.RoundedRectangle,
                new RoundedRectangle { X = x, Y = y, W = w, H = h, RadiusX = radiusX, RadiusY = radiusY }
                );

        }

        public static CanvasGeometry CreateEllipse(CanvasDevice device, float x, float y, float radiusX, float radiusY)
        {
            return new CanvasGeometry(
                GeometryType.Ellipse,
                new Ellipse { X = x, Y = y, RadiusX = radiusX, RadiusY = radiusY }
                );
        }

        public CanvasGeometry CombineWith(CanvasGeometry other, Matrix3x2 matrix, CanvasGeometryCombine combineMode)
        {
            return new CanvasGeometry(
                GeometryType.Combination,
                new Combination { A = this, B = other, Matrix = matrix, CombineMode = combineMode }
                );
        }

        public object Content { get; }

        public GeometryType Type { get; }

        public sealed class Combination
        {
            public CanvasGeometry A { get; internal set; }
            public CanvasGeometry B { get; internal set; }
            public Matrix3x2 Matrix { get; internal set; }
            public CanvasGeometryCombine CombineMode { get; internal set; }
        }

        public sealed class Ellipse
        {
            public float X { get; internal set; }
            public float Y { get; internal set; }
            public float RadiusX { get; internal set; }
            public float RadiusY { get; internal set; }
        }

        public sealed class RoundedRectangle
        {
            public float X { get; internal set; }
            public float Y { get; internal set; }
            public float W { get; internal set; }
            public float H { get; internal set; }
            public float RadiusX { get; internal set; }
            public float RadiusY { get; internal set; }
        }
    }
}
