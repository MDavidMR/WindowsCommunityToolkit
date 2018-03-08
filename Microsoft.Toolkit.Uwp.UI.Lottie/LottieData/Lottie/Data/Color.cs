namespace Lottie.Data
{
    public sealed class Color
    {
        Color(byte a, byte r, byte g, byte b) { A = a; R = r; G = g; B = b; }

        public static Color FromArgb(byte a, byte r, byte g, byte b)
        {
            return new Color(a, r, g, b);
        }

        public byte A { get; }
        public byte B { get; }
        public byte G { get; }
        public byte R { get; }
    }
}
