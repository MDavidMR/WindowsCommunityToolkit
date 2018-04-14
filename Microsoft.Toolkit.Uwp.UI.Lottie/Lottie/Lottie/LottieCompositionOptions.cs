using System;

namespace Lottie
{
    /// <summary>
    /// Options for controlling what information is added to the <see cref="CompositionPlayerSource.Diagnostics"/> 
    /// object when a <see cref="LottieComposition"/> is loaded.
    /// </summary>
    [Flags]
    public enum LottieCompositionOptions
    {
        None = 0,

        /// <summary>
        /// Include an XML version of the Lottie and the Windows.UI.Composition translation into
        /// the <see cref="CompositionPlayerSource.Diagnostics"/> object.
        /// </summary>
        IncludeXmlToDiagnostics = 1,

        /// <summary>
        /// Include the C# code that would generate the Composition objects for the Lottie.
        /// </summary>
        IncludeCSharpGeneratedCode = 2,

        All = IncludeXmlToDiagnostics | IncludeCSharpGeneratedCode,
    }
}
