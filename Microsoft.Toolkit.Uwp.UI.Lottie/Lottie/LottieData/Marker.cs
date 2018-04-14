namespace LottieData
{
#if !WINDOWS_UWP
    public
#endif
    sealed class Marker : LottieObject
    {
        public Marker(
            double frame, 
            string name,
            bool flag) : base(name)
        {
            Frame = frame;
            Flag = flag;
        }

        public double Frame { get; }

        public bool Flag { get; }

        public override LottieObjectType ObjectType => LottieObjectType.Marker;
    }
}
