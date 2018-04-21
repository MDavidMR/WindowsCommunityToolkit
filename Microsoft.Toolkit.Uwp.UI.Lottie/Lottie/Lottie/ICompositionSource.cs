namespace Lottie
{
    public interface ICompositionSource
    {
        void ConnectSink(ICompositionSink sink);
        void DisconnectSink(ICompositionSink sink);
    }
}
