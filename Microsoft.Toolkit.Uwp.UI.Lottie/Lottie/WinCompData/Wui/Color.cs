namespace WinCompData.Wui
{
#if !WINDOWS_UWP
    public
#endif
    sealed class Color
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

        public override string ToString() => $"#{ToHex(A)}{ToHex(R)}{ToHex(G)}{ToHex(B)}";

        static string ToHex(byte value) => value.ToString("X2");

    }
}
