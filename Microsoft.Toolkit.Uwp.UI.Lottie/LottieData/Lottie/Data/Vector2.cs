namespace Lottie.Data
{
    public struct Vector2
    {
        public Vector2(float x, float y)
        {
            X = x;
            Y = y;
        }

        public float X { get; }
        public float Y { get; }

        public static Vector2 operator *(Vector2 left, float right) =>
            new Vector2(left.X * right, left.Y * right);


        public static Vector2 operator +(Vector2 left, Vector2 right) =>
            new Vector2(left.X + right.X, left.Y + right.Y);
    }
}
