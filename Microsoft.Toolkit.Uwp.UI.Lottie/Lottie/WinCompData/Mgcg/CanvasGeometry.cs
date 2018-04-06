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
        CanvasGeometry(object state)
        {
            Content = state;
        }

        public static CanvasGeometry CreatePath(CanvasPathBuilder pathBuilder)
        {
            return new CanvasGeometry(pathBuilder);
        }

        public static CanvasGeometry CreateRoundedRectangle(CanvasDevice device, float a, float b, float c, float d, float e, float f) => null;
        public static CanvasGeometry CreateEllipse(CanvasDevice device, float a, float b, float c, float d) => null;

        public CanvasGeometry CombineWith(CanvasGeometry other, Matrix3x2 matrix, CanvasGeometryCombine combineMode)
        {
            return new CanvasGeometry(new Combination { A = this, B = other, Matrix = matrix, CombineMode = combineMode });
        }

        public object Content { get; private set; }

        public sealed class Combination
        {
            public CanvasGeometry A;
            public CanvasGeometry B;
            public Matrix3x2 Matrix;
            public CanvasGeometryCombine CombineMode;
        }
    }
}
