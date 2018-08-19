// Copyright(c) Microsoft Corporation.All rights reserved.
// Licensed under the MIT License.

namespace WinCompData.Sn
{
#if !WINDOWS_UWP
    public
#endif
    readonly struct Matrix3x2
    {
        public readonly float M11;
        public readonly float M12;
        public readonly float M21;
        public readonly float M22;
        public readonly float M31;
        public readonly float M32;

        public static Matrix3x2 Identity => new Matrix3x2(m11: 1, 0, 0, m22: 1, 0, 0);

        public Matrix3x2(float m11, float m12, float m21, float m22, float m31, float m32)
        {
            M11 = m11;
            M12 = m12;
            M21 = m21;
            M22 = m22;
            M31 = m31;
            M32 = m32;
        }

        public bool IsIdentity => M11 == 1 && M12 == 0 && M21 == 0 && M22 == 1 && M31 == 0 && M32 == 0;
    }
}
