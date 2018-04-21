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
            double durationSeconds) : base(name)
        {
            Frame = frame;
            DurationSeconds = durationSeconds;
        }

        public double Frame { get; }

        public double DurationSeconds { get; }

        public override LottieObjectType ObjectType => LottieObjectType.Marker;
    }
}
