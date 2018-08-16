// Copyright(c) Microsoft Corporation.All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LottieData
{
#if !WINDOWS_UWP
    public
#endif
    sealed class GradientStopCollection : IEquatable<GradientStopCollection>
    {
        readonly GradientStop[] _gradientStops;

        public GradientStopCollection(IEnumerable<GradientStop> gradientStops)
        {
            _gradientStops = gradientStops.ToArray();
        }

        public struct GradientStop
        {
            public GradientStop(double offset, Color color, double? opacity = null)
            {
                Offset = offset;
                Color = color;
                Opacity = opacity;
                if (Color.A != 1.0)
                {
                    throw new ArgumentException();
                }
            }

            public GradientStop(double offset, double opacity)
            {
                Offset = offset;
                Color = null;
                Opacity = opacity;
            }

            public double Offset { get; }
            public Color Color { get; }
            public double? Opacity { get; }

            public override string ToString()
            {
                return $"{this.GetType().Name}: RGBA({Color.R}, {Color.G}, {Color.B}, {Opacity ?? Color.A})@{Offset}";
            }
        }

        public IEnumerable<GradientStop> GradientStops => _gradientStops;

        public bool Equals(GradientStopCollection other) => Enumerable.SequenceEqual<GradientStop>(GradientStops, other.GradientStops);

        public override string ToString()
        {
            return $"{this.GetType().Name}: {String.Join(",", GradientStops.Select(p => p.ToString()).ToArray())}";
        }
    }
}
