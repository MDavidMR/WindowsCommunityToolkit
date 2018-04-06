using System.Collections.Generic;
using WinCompData.Tools;

namespace WinCompData
{
#if !WINDOWS_UWP
    public
#endif
    sealed class CompositionContainerShape : CompositionShape
    {
        internal CompositionContainerShape() { }

        public ListOfNeverNull<CompositionShape> Shapes { get; } = new ListOfNeverNull<CompositionShape>();

        public override ConcreteClassType Type => ConcreteClassType.CompositionContainerShape;
    }
}
