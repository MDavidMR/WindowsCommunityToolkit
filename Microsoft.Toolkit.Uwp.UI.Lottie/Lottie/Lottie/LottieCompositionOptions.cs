using System;

namespace Lottie
{
    /// <summary>
    /// Options for controlling how the <see cref="LottieCompositionSource"/> processes a Lottie file.
    /// </summary>
    [Flags]
    public enum LottieCompositionOptions
    {
        None = 0,

        /// <summary>
        /// Include an XML version of the Lottie and the Windows.UI.Composition translation in
        /// the <see cref="CompositionPlayer.Diagnostics"/> object.
        /// </summary>
        DiagnosticsIncludeXml = 1,

        /// <summary>
        /// Include C# code that generates the <see cref="CompositionPlayer.Source"/> objects in
        /// the <see cref="CompositionPlayer.Diagnostics"/> object.
        /// </summary>
        DiagnosticsIncludeCSharpGeneratedCode = 2,

        All = DiagnosticsIncludeXml | DiagnosticsIncludeCSharpGeneratedCode,
    }
}
