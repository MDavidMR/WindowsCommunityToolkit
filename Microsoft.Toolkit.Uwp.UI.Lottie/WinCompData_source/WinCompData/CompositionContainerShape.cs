// Copyright(c) Microsoft Corporation.All rights reserved.
// Licensed under the MIT License.

using WinCompData.Tools;

namespace WinCompData
{
#if !WINDOWS_UWP
    public
#endif
    sealed class CompositionContainerShape : CompositionShape, IContainShapes, ListOfNeverNull<CompositionShape>.IListOfNeverNullOwner
    {
        internal CompositionContainerShape()
        {
            Shapes = new ListOfNeverNull<CompositionShape>(this);
        }

        public ListOfNeverNull<CompositionShape> Shapes { get; }

        public override CompositionObjectType Type => CompositionObjectType.CompositionContainerShape;

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
