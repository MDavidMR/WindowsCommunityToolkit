namespace WinCompData.Sn
{
#if !WINDOWS_UWP
    public
#endif
    struct Vector3
    {
        public Vector3(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public float X { get; }
        public float Y { get; }
        public float Z { get; }

        public override string ToString() => $"{{{X},{Y},{Z}}}";

        public static Vector3 One { get; } = new Vector3(1, 1, 1);

        public static Vector3 operator *(Vector3 left, float right) => new Vector3(left.X * right, left.Y * right, left.Z * right);
        public static Vector3 operator -(Vector3 left, float right) => new Vector3(left.X - right, left.Y - right, left.Z - right);
        public static Vector3 operator -(Vector3 left, Vector3 right) => new Vector3(left.X - right.X, left.Y - right.Y, left.Y - right.Y);


    }
}


