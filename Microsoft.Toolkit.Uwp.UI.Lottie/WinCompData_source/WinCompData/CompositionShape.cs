// Copyright(c) Microsoft Corporation.All rights reserved.
// Licensed under the MIT License.

using WinCompData.Sn;

namespace WinCompData
{
#if !WINDOWS_UWP
    public
#endif
    abstract class CompositionShape : CompositionObject, CompositionObject.IContainedBy<IContainShapes>
    {
        internal CompositionShape() { }

        public IContainShapes Parent { get; private set; }
        public Vector2? CenterPoint { get; set; }
        public Vector2? Offset { get; set; }
        public float? RotationAngleInDegrees { get; set; }
        public Vector2? Scale { get; set; }
        public Matrix3x2? TransformMatrix { get; set; }

        void IContainedBy<IContainShapes>.SetParent(IContainShapes parent)
        {
            Parent = parent;
        }
    }
}
