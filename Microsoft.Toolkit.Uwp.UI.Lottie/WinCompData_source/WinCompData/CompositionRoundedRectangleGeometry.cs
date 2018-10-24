// Copyright(c) Microsoft Corporation.All rights reserved.
// Licensed under the MIT License.

using System.Numerics;

namespace WinCompData
{
#if !WINDOWS_UWP
    public
#endif
    sealed class CompositionRoundedRectangleGeometry : CompositionGeometry
    {
        public Vector2 CornerRadius { get; set; }

        public Vector2? Offset { get; set; }

        public Vector2 Size { get; set; }

        public override CompositionObjectType Type => CompositionObjectType.CompositionRoundedRectangleGeometry;
    }
}