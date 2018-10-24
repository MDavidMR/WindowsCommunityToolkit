// Copyright(c) Microsoft Corporation.All rights reserved.
// Licensed under the MIT License.

using WinCompData.Tools;

namespace WinCompData
{
#if !WINDOWS_UWP
    public
#endif
    interface IContainShapes
    {
        ListOfNeverNull<CompositionShape> Shapes { get; }
    }
}