// Copyright(c) Microsoft Corporation.All rights reserved.
// Licensed under the MIT License.

namespace Lottie
{
    public sealed class Issue
    {
        public string Code { get; set; }
        public string Description { get; set; }


        public override string ToString() => $"{Code}: {Description}";
    }
}
