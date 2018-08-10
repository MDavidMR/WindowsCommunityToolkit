// Copyright(c) Microsoft Corporation.All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;

namespace LottieData
{
    /// <summary>
    /// A geometric figure. The geometry is represented as a series of 
    /// cubic bezier segments.
    /// </summary>
#if !WINDOWS_UWP
    public
#endif
    sealed class PathGeometry : IEquatable<PathGeometry>
    {
        readonly BezierSegment[] _beziers;

        public PathGeometry(IEnumerable<BezierSegment> beziers)
        {
            _beziers = beziers.ToArray();
        }

        /// <summary>
        /// The beziers that make up the figure.
        /// </summary>
        public IEnumerable<BezierSegment> Beziers => _beziers;

        public bool Equals(PathGeometry other) =>
            other != null &&
            Enumerable.SequenceEqual(Beziers, other.Beziers, BezierSegment.EqualityComparer);
    }
}
