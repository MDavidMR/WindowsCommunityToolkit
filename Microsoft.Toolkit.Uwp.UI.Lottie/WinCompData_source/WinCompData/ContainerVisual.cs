// Copyright(c) Microsoft Corporation.All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using WinCompData.Tools;

namespace WinCompData
{
#if !WINDOWS_UWP
    public
#endif
    class ContainerVisual : Visual
    {
        internal ContainerVisual()
        {
            Children = new ListOfNeverNull<Visual>();
        }

        public ListOfNeverNull<Visual> Children { get; }

        public override CompositionObjectType Type => CompositionObjectType.ContainerVisual;
    }
}
