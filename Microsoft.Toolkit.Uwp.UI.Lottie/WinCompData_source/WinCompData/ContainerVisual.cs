// Copyright(c) Microsoft Corporation.All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using WinCompData.Tools;

namespace WinCompData
{
#if !WINDOWS_UWP
    public
#endif
    class ContainerVisual : Visual, ListOfNeverNull<Visual>.IListOfNeverNullOwner
    {
        internal ContainerVisual()
        {
            Children = new ListOfNeverNull<Visual>(this);
        }

        public ListOfNeverNull<Visual> Children { get; }

        public override CompositionObjectType Type => CompositionObjectType.ContainerVisual;

        void ListOfNeverNull<Visual>.IListOfNeverNullOwner.ItemAdded(Visual item)
        {
            ((IContainedBy<ContainerVisual>)item).SetParent(this);
        }

        void ListOfNeverNull<Visual>.IListOfNeverNullOwner.ItemRemoved(Visual item)
        {
            ((IContainedBy<ContainerVisual>)item).SetParent(null);
        }
    }
}
