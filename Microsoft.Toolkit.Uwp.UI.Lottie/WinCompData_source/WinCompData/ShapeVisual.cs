// Copyright(c) Microsoft Corporation.All rights reserved.
// Licensed under the MIT License.

using WinCompData.Tools;

namespace WinCompData
{
#if !WINDOWS_UWP
    public
#endif
    sealed class ShapeVisual : ContainerVisual, IContainShapes
    {
        internal ShapeVisual()
        {
            Shapes = new ListOfNeverNull<CompositionShape>();
        }

        public ListOfNeverNull<CompositionShape> Shapes { get; }

        public CompositionViewBox ViewBox { get; set; }

        public override CompositionObjectType Type => CompositionObjectType.ShapeVisual;
    }
}
