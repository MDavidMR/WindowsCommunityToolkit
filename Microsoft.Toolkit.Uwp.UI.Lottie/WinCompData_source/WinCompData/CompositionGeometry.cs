// Copyright(c) Microsoft Corporation.All rights reserved.
// Licensed under the MIT License.

namespace WinCompData
{
#if !WINDOWS_UWP
    public
#endif
    abstract class CompositionGeometry : CompositionObject
    {
        internal CompositionGeometry() { }

        // Default = 1
        public float TrimEnd { get; set; } = 1;

        // Default = 0
        public float TrimOffset { get; set; }

        // Default = 0
        public float TrimStart { get; set; }

    }
}
