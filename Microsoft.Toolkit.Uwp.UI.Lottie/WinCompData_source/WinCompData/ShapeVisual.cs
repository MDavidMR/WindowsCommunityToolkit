// Copyright(c) Microsoft Corporation.All rights reserved.
// Licensed under the MIT License.

using WinCompData.Tools;

namespace WinCompData
{
#if !WINDOWS_UWP
    public
#endif
    sealed class ShapeVisual : ContainerVisual, IContainShapes, ListOfNeverNull<CompositionShape>.IListOfNeverNullOwner
    {
        internal ShapeVisual()
        {
            Shapes = new ListOfNeverNull<CompositionShape>(this);
        }

        public ListOfNeverNull<CompositionShape> Shapes { get; }

        public CompositionViewBox ViewBox { get; set; }

        public override CompositionObjectType Type => CompositionObjectType.ShapeVisual;

        void ListOfNeverNull<CompositionShape>.IListOfNeverNullOwner.ItemAdded(CompositionShape item)
        {
            ((IContainedBy<IContainShapes>)item).SetParent(this);
        }

        void ListOfNeverNull<CompositionShape>.IListOfNeverNullOwner.ItemRemoved(CompositionShape item)
        {
            ((IContainedBy<IContainShapes>)item).SetParent(null);
        }
    }
}
