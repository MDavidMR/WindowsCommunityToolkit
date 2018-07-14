// Copyright(c) Microsoft Corporation.All rights reserved.
// Licensed under the MIT License.

using WinCompData.Tools;

namespace WinCompData
{
#if !WINDOWS_UWP
    public
#endif
    sealed class CompositionContainerShape : CompositionShape, IContainShapes
    {
        internal CompositionContainerShape() { }

        public ListOfNeverNull<CompositionShape> Shapes { get; } = new ListOfNeverNull<CompositionShape>();

        public override CompositionObjectType Type => CompositionObjectType.CompositionContainerShape;
    }
}
