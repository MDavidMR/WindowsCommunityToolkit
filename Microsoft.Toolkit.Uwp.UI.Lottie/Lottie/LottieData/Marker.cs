namespace LottieData
{
#if !WINDOWS_UWP
    public
#endif
    sealed class Marker
    {
        public Marker(
            double progress, 
            string name,
            bool flag)
        {
            Progress = progress;
            Name = name;
            Flag = flag;
        }

        public double Progress { get; }
        public string Name { get; }
        public bool Flag { get; }
    }
}
