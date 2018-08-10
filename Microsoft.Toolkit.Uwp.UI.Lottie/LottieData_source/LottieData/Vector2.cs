// Copyright(c) Microsoft Corporation.All rights reserved.
// Licensed under the MIT License.

using System;

namespace LottieData
{
#if !WINDOWS_UWP
    public
#endif
    struct Vector2 : IEquatable<Vector2>
    {
        public Vector2(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double X { get; }
        public double Y { get; }

        public static Vector2 Zero { get; } = new Vector2(0, 0);

        public static Vector2 One { get; } = new Vector2(1, 1);

        public static Vector2 operator *(Vector2 left, double right) =>
            new Vector2(left.X * right, left.Y * right);

        public static Vector2 operator +(Vector2 left, Vector2 right) =>
            new Vector2(left.X + right.X, left.Y + right.Y);

        public static Vector2 operator -(Vector2 left, Vector2 right) =>
            new Vector2(left.X - right.X, left.Y - right.Y);

        public static bool operator ==(Vector2 left, Vector2 right) => left.Equals(right);
        public static bool operator !=(Vector2 left, Vector2 right) => !left.Equals(right);

        public override bool Equals(object obj) => obj is Vector2 && Equals((Vector2)obj);
        public bool Equals(Vector2 other) => X == other.X && Y == other.Y;
        public override int GetHashCode() => (X * Y).GetHashCode();
        public override string ToString() => $"{{{X},{Y}}}";
    }
}

