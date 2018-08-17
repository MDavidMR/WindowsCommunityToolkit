// Copyright(c) Microsoft Corporation.All rights reserved.
// Licensed under the MIT License.

using System;

namespace WinCompData
{
#if !WINDOWS_UWP
    public
#endif
    abstract class CompositionEasingFunction : CompositionObject
    {
        protected private CompositionEasingFunction() { }
    }
}
