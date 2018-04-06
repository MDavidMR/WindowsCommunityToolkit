using System.Collections.Generic;
using WinCompData.Tools;

namespace WinCompData
{
#if !WINDOWS_UWP
    public
#endif
    sealed class ShapeVisual : ContainerVisual
    {
        internal ShapeVisual() { }
        public ListOfNeverNull<CompositionShape> Shapes { get; } = new ListOfNeverNull<CompositionShape>();

        public CompositionViewBox ViewBox { get; set; }

        public override ConcreteClassType Type => ConcreteClassType.ShapeVisual;
    }
}
