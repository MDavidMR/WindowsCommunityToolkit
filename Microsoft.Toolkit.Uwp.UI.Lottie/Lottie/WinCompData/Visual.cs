// Copyright(c) Microsoft Corporation.All rights reserved.
// Licensed under the MIT License.

using WinCompData.Sn;

namespace WinCompData
{
#if !WINDOWS_UWP
    public
#endif
    abstract class Visual : CompositionObject
    {
        internal Visual() { }
        public Vector3? CenterPoint { get; set; }
        public CompositionClip Clip { get; set; }
        public Vector3? Offset { get; set; }
        public float? RotationAngleInDegrees { get; set; }
        public Vector3? Scale { get; set; }
        public Vector2? Size { get; set; }
    }
}
