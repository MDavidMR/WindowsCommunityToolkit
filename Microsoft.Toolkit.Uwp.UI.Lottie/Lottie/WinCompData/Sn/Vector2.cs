namespace WinCompData.Sn
{
#if !WINDOWS_UWP
    public
#endif
    struct Vector2
    {
        public Vector2(float x, float y)
        {
            X = x;
            Y = y;
        }

        public float X { get; }
        public float Y { get; }

        public override string ToString() => $"{{{X},{Y}}}";

        public static Vector2 One { get; } = new Vector2(1, 1);

        public static Vector2 operator *(Vector2 left, float right) => new Vector2(left.X * right, left.Y * right);
        public static Vector2 operator /(Vector2 left, float right) => new Vector2(left.X / right, left.Y / right);
        public static Vector2 operator -(Vector2 left, float right) => new Vector2(left.X - right, left.Y - right);
        public static Vector2 operator -(Vector2 left, Vector2 right) => new Vector2(left.X - right.X, left.Y - right.Y);
        public static Vector2 operator +(Vector2 left, Vector2 right) => new Vector2(left.X + right.X, left.Y + right.Y);
    }
}


