using System;
using System.Collections.Generic;

namespace Lottie
{
    /// <summary>
    /// Diagnostics information about a Lottie and its translation.
    /// </summary>
    public sealed class LottieCompositionDiagnostics
    {
        static readonly string[] s_emptyStrings = new string[0];
        static readonly KeyValuePair<string, double>[] s_emptyMarkers = new KeyValuePair<string, double>[0];

        public string FileName { get; internal set; } = "";

        public TimeSpan Duration { get; internal set; }

        public TimeSpan ReadTime { get; internal set; }

        public TimeSpan ParseTime { get; internal set; }

        public TimeSpan ValidationTime { get; internal set; }

        public TimeSpan TranslationTime { get; internal set; }

        public TimeSpan InstantiationTime { get; internal set; }

        public IEnumerable<string> JsonParsingIssues { get; internal set; } = s_emptyStrings;

        public IEnumerable<string> LottieValidationIssues { get; internal set; } = s_emptyStrings;

        public IEnumerable<string> TranslationIssues { get; internal set; } = s_emptyStrings;

        public double LottieWidth { get; internal set; }

        public double LottieHeight { get; internal set; }

        public string LottieDetails { get; internal set; } = "";

        public string LottieXml { get; internal set; } = "";

        public string WinCompXml { get; internal set; } = "";

        public string WinCompCSharp { get; internal set; } = "";

        public KeyValuePair<string, double>[] Markers { get; internal set; } = s_emptyMarkers;
    }
}
