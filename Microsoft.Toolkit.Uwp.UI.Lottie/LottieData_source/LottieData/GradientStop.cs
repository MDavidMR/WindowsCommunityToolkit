// Copyright(c) Microsoft Corporation.All rights reserved.
// Licensed under the MIT License.

using System;

namespace LottieData
{
#if !WINDOWS_UWP
    public
#endif
struct GradientStop
    {
        public GradientStop(double offset, Color color, double? opacity)
        {
            if (color != null)
            {
                if (color.A != 1)
                {
                    throw new ArgumentException("Color must have an alpha of 1");
                }
            }
            else if (opacity == null)
            {
                throw new ArgumentException("Color or opacity must be specified");
            }

            Offset = offset;
            Color = color;
            Opacity = opacity;
        }

        public static GradientStop FromColor(double offset, Color color) => new GradientStop(offset, color, null);

        public static GradientStop FromOpacity(double offset, double opacity) => new GradientStop(offset, null, opacity);

        public double Offset { get; }
        public Color Color { get; }
        public double? Opacity { get; }

        public override string ToString()
        {
            var rgb = Color == null 
                ? "??????" 
                : $"{ToHex(Color.R)}{ToHex(Color.G)}{ToHex(Color.B)}";

            var opacity = Opacity.HasValue
                ? ToHex(Opacity.Value)
                : "??";

            return $"#{opacity}{rgb}@{Offset}";
        }

        static string ToHex(double value) => ((byte)(value * 255)).ToString("X2");
    }
}