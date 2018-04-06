﻿using WinCompData.Sn;

namespace WinCompData
{
#if !WINDOWS_UWP
    public
#endif
    sealed class Vector2KeyFrameAnimation : KeyFrameAnimation<Vector2>
    {
        internal Vector2KeyFrameAnimation() : base(null) { }
        Vector2KeyFrameAnimation(Vector2KeyFrameAnimation other) : base(other) { }

        public override ConcreteClassType Type => ConcreteClassType.Vector2KeyFrameAnimation;

        internal override CompositionAnimation Clone() => new Vector2KeyFrameAnimation(this);
    }
}
