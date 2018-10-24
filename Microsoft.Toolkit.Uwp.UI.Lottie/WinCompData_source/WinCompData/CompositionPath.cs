// Copyright(c) Microsoft Corporation.All rights reserved.
// Licensed under the MIT License.

namespace WinCompData
{
#if !WINDOWS_UWP
    public
#endif
    sealed class CompositionPath : IDescribable
    {
        public CompositionPath(Wg.IGeometrySource2D source)
        {
            Source = source;
        }

        public Wg.IGeometrySource2D Source { get; }
        public string LongDescription { get; set; }
        public string ShortDescription { get; set; }
    }
}
