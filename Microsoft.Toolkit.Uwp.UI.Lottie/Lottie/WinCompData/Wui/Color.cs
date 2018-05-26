using System;

namespace WinCompData.Wui
{
#if !WINDOWS_UWP
    public
#endif
    struct Color : IEquatable<Color>
    {
        Color(byte a, byte r, byte g, byte b) { A = a; R = r; G = g; B = b; }

        public static Color FromArgb(byte a, byte r, byte g, byte b) => new Color(a, r, g, b);

        public byte A { get; }
        public byte B { get; }
        public byte G { get; }
        public byte R { get; }

        public override string ToString() => TryGetFriendlyName(out var name) ? name : $"#{Hex}";

        public bool Equals(Color other) => A == other.A && R == other.R && G == other.G && B == other.B;
        public override bool Equals(object obj) => obj is Color && Equals((Color)obj);
        public override int GetHashCode() => A * R * G * B;

        public static bool operator ==(Color left, Color right) => left.Equals(right);
        public static bool operator !=(Color left, Color right) => !left.Equals(right);

        /// <summary>
        /// Returns a string that describes the color for human consumption. This either returns
        /// the well known name for the color, or 8 hex digits (with no prefix).
        /// The returned value is similar to what <see cref="ToString"/> returns but does not
        /// contain any characters that are unsuitable for use in identifiers.
        /// </summary>
        public string Name => TryGetFriendlyName(out var name) ? name : Hex;

        /// <summary>
        /// Attempts to get the friendly name for this color.
        /// </summary>
        public bool TryGetFriendlyName(out string name)
        {
            name = GetFriendlyName(A, R, G, B);
            return name != null;
        }

        /// <summary>
        /// Returns the hex representation of this color.
        /// </summary>
        public string Hex => $"{ToHex(A)}{ToHex(R)}{ToHex(G)}{ToHex(B)}";

        // Gets the friendly name if one exists, or null. 
        // The same name will not be returned for more than one ARGB value.
        // The result is slightly different form GetWellKnownName in that it will
        // return some not-well-known-but-still-friendly names for transparent values.
        static string GetFriendlyName(byte a, byte r, byte g, byte b)
        {
            if (a == 0)
            {
                var transparentColor = GetWellKnownName(0xFF, r, g, b);
                return (transparentColor != null) ? $"Transparent{transparentColor}" : null;
            }
            else
            {
                return GetWellKnownName(a, r, g, b);
            }
        }

        // Gets the well known name.
        static string GetWellKnownName(byte a, byte r, byte g, byte b)
        {
            switch (((uint)a << 24) | ((uint)r << 16) | ((uint)g << 8) | b)
            {
                case 0x00000000: return "Transparent";
                case 0xFF000000: return "Black";
                case 0xFF000080: return "Navy";
                case 0xFF00008B: return "DarkBlue";
                case 0xFF0000CD: return "MediumBlue";
                case 0xFF0000FF: return "Blue";
                case 0xFF006400: return "DarkGreen";
                case 0xFF008000: return "Green";
                case 0xFF008080: return "Teal";
                case 0xFF008B8B: return "DarkCyan";
                case 0xFF00BFFF: return "DeepSkyBlue";
                case 0xFF00CED1: return "DarkTurquoise";
                case 0xFF00FA9A: return "MediumSpringGreen";
                case 0xFF00FF00: return "Lime";
                case 0xFF00FF7F: return "SpringGreen";
                // Aqua and Cyan have the same value.
                //case 0xFF00FFFF: return "Aqua";
                case 0xFF00FFFF: return "Cyan";
                case 0xFF191970: return "MidnightBlue";
                case 0xFF1E90FF: return "DodgerBlue";
                case 0xFF20B2AA: return "LightSeaGreen";
                case 0xFF228B22: return "ForestGreen";
                case 0xFF2E8B57: return "SeaGreen";
                case 0xFF2F4F4F: return "DarkSlateGray";
                case 0xFF32CD32: return "LimeGreen";
                case 0xFF3CB371: return "MediumSeaGreen";
                case 0xFF40E0D0: return "Turquoise";
                case 0xFF4169E1: return "RoyalBlue";
                case 0xFF4682B4: return "SteelBlue";
                case 0xFF483D8B: return "DarkSlateBlue";
                case 0xFF48D1CC: return "MediumTurquoise";
                case 0xFF4B0082: return "Indigo";
                case 0xFF556B2F: return "DarkOliveGreen";
                case 0xFF5F9EA0: return "CadetBlue";
                case 0xFF6495ED: return "CornflowerBlue";
                case 0xFF66CDAA: return "MediumAquamarine";
                case 0xFF696969: return "DimGray";
                case 0xFF6A5ACD: return "SlateBlue";
                case 0xFF6B8E23: return "OliveDrab";
                case 0xFF708090: return "SlateGray";
                case 0xFF778899: return "LightSlateGray";
                case 0xFF7B68EE: return "MediumSlateBlue";
                case 0xFF7CFC00: return "LawnGreen";
                case 0xFF7FFF00: return "Chartreuse";
                case 0xFF7FFFD4: return "Aquamarine";
                case 0xFF800000: return "Maroon";
                case 0xFF800080: return "Purple";
                case 0xFF808000: return "Olive";
                case 0xFF808080: return "Gray";
                case 0xFF87CEEB: return "SkyBlue";
                case 0xFF87CEFA: return "LightSkyBlue";
                case 0xFF8A2BE2: return "BlueViolet";
                case 0xFF8B0000: return "DarkRed";
                case 0xFF8B008B: return "DarkMagenta";
                case 0xFF8B4513: return "SaddleBrown";
                case 0xFF8FBC8F: return "DarkSeaGreen";
                case 0xFF90EE90: return "LightGreen";
                case 0xFF9370DB: return "MediumPurple";
                case 0xFF9400D3: return "DarkViolet";
                case 0xFF98FB98: return "PaleGreen";
                case 0xFF9932CC: return "DarkOrchid";
                case 0xFF9ACD32: return "YellowGreen";
                case 0xFFA0522D: return "Sienna";
                case 0xFFA52A2A: return "Brown";
                case 0xFFA9A9A9: return "DarkGray";
                case 0xFFADD8E6: return "LightBlue";
                case 0xFFADFF2F: return "GreenYellow";
                case 0xFFAFEEEE: return "PaleTurquoise";
                case 0xFFB0C4DE: return "LightSteelBlue";
                case 0xFFB0E0E6: return "PowderBlue";
                case 0xFFB22222: return "Firebrick";
                case 0xFFB8860B: return "DarkGoldenrod";
                case 0xFFBA55D3: return "MediumOrchid";
                case 0xFFBC8F8F: return "RosyBrown";
                case 0xFFBDB76B: return "DarkKhaki";
                case 0xFFC0C0C0: return "Silver";
                case 0xFFC71585: return "MediumVioletRed";
                case 0xFFCD5C5C: return "IndianRed";
                case 0xFFCD853F: return "Peru";
                case 0xFFD2691E: return "Chocolate";
                case 0xFFD2B48C: return "Tan";
                case 0xFFD3D3D3: return "LightGray";
                case 0xFFD8BFD8: return "Thistle";
                case 0xFFDA70D6: return "Orchid";
                case 0xFFDAA520: return "Goldenrod";
                case 0xFFDB7093: return "PaleVioletRed";
                case 0xFFDC143C: return "Crimson";
                case 0xFFDCDCDC: return "Gainsboro";
                case 0xFFDDA0DD: return "Plum";
                case 0xFFDEB887: return "BurlyWood";
                case 0xFFE0FFFF: return "LightCyan";
                case 0xFFE6E6FA: return "Lavender";
                case 0xFFE9967A: return "DarkSalmon";
                case 0xFFEE82EE: return "Violet";
                case 0xFFEEE8AA: return "PaleGoldenrod";
                case 0xFFF08080: return "LightCoral";
                case 0xFFF0E68C: return "Khaki";
                case 0xFFF0F8FF: return "AliceBlue";
                case 0xFFF0FFF0: return "Honeydew";
                case 0xFFF0FFFF: return "Azure";
                case 0xFFF4A460: return "SandyBrown";
                case 0xFFF5DEB3: return "Wheat";
                case 0xFFF5F5DC: return "Beige";
                case 0xFFF5F5F5: return "WhiteSmoke";
                case 0xFFF5FFFA: return "MintCream";
                case 0xFFF8F8FF: return "GhostWhite";
                case 0xFFFA8072: return "Salmon";
                case 0xFFFAEBD7: return "AntiqueWhite";
                case 0xFFFAF0E6: return "Linen";
                case 0xFFFAFAD2: return "LightGoldenrodYellow";
                case 0xFFFDF5E6: return "OldLace";
                case 0xFFFF0000: return "Red";
                // Fuchsia and Magenta have the same value.
                //case 0xFFFF00FF: return "Fuchsia";
                case 0xFFFF00FF: return "Magenta";
                case 0xFFFF1493: return "DeepPink";
                case 0xFFFF4500: return "OrangeRed";
                case 0xFFFF6347: return "Tomato";
                case 0xFFFF69B4: return "HotPink";
                case 0xFFFF7F50: return "Coral";
                case 0xFFFF8C00: return "DarkOrange";
                case 0xFFFFA07A: return "LightSalmon";
                case 0xFFFFA500: return "Orange";
                case 0xFFFFB6C1: return "LightPink";
                case 0xFFFFC0CB: return "Pink";
                case 0xFFFFD700: return "Gold";
                case 0xFFFFDAB9: return "PeachPuff";
                case 0xFFFFDEAD: return "NavajoWhite";
                case 0xFFFFE4B5: return "Moccasin";
                case 0xFFFFE4C4: return "Bisque";
                case 0xFFFFE4E1: return "MistyRose";
                case 0xFFFFEBCD: return "BlanchedAlmond";
                case 0xFFFFEFD5: return "PapayaWhip";
                case 0xFFFFF0F5: return "LavenderBlush";
                case 0xFFFFF5EE: return "SeaShell";
                case 0xFFFFF8DC: return "Cornsilk";
                case 0xFFFFFACD: return "LemonChiffon";
                case 0xFFFFFAF0: return "FloralWhite";
                case 0xFFFFFAFA: return "Snow";
                case 0xFFFFFF00: return "Yellow";
                case 0xFFFFFFE0: return "LightYellow";
                case 0xFFFFFFF0: return "Ivory";
                case 0xFFFFFFFF: return "White";
                default:
                    return null;
            }
        }

        static string ToHex(byte value) => value.ToString("X2");
    }
}
