// Copyright(c) Microsoft Corporation.All rights reserved.
// Licensed under the MIT License.

namespace LottieData
{
#if !WINDOWS_UWP
    public
#endif
    sealed class Repeater : ShapeLayerContent
    {
        public Repeater(
            string name,
            string matchName)
            : base(name, matchName)
        {
        }

        public override ShapeContentType ContentType => ShapeContentType.Repeater;

        public override LottieObjectType ObjectType => LottieObjectType.Repeater;
    }
}
