using WinCompData.Sn;

namespace WinCompData
{
#if !WINDOWS_UWP
    public
#endif
    abstract class CompositionClip : CompositionObject
    {
        internal CompositionClip() {  }

        public Vector2? CenterPoint { get; set; }

        public Vector2? Scale { get; set; }
    }
}
