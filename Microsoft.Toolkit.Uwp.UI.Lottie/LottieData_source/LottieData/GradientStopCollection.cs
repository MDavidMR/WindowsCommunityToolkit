// Copyright(c) Microsoft Corporation.All rights reserved.
// Licensed under the MIT License.

using System;
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

        public IEnumerable<GradientStop> GradientStops => _gradientStops;

        public bool Equals(GradientStopCollection other) => Enumerable.SequenceEqual(GradientStops, other.GradientStops);

        public override string ToString() => $"GradientStops: {String.Join(",", GradientStops)}";
    }
}
