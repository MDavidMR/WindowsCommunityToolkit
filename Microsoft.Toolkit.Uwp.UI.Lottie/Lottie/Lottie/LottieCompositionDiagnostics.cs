using System;
using System.Collections.Generic;

namespace Lottie
{
    /// <summary>
    /// Diagnostics information about a Lottie and its translation.
    /// </summary>
    public sealed class LottieCompositionDiagnostics
    {
        public string FileName { get; internal set; }

        public TimeSpan Duration { get; internal set; }

        public TimeSpan ParseTime { get; internal set; }

        public TimeSpan ValidationTime { get; internal set; }

        public TimeSpan TranslationTime { get; internal set; }

        public TimeSpan InstantiationTime { get; internal set; }

        public IEnumerable<string> JsonParsingIssues { get; internal set; }

        public IEnumerable<string> LottieValidationIssues { get; internal set; }

        public IEnumerable<string> TranslationIssues { get; internal set; }

        public string LottieDetails { get; internal set; }

        public string LottieXml { get; internal set; }

        public string WinCompXml { get; internal set; }

    }
}
