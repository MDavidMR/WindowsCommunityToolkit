
namespace Lottie
{
    internal sealed class CompositionLoadResult
    {
        internal bool LoadSucceeded { get; set; }

        internal AnimatedComposition Composition { get; set; }

        /// <summary>
        /// Optional diagnostics information.
        /// </summary>
        internal object Diagnostics { get; set; }
    }
}
