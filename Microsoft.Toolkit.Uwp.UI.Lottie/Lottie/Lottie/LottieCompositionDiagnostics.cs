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
        string _lottieXml;
        string _winCompXml;
        string _winCompCSharp;

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
        public string LottieVersion { get; internal set; }

        /// <summary>
        /// The options that were set on the <see cref="LottieCompositionSource"/> when it 
        /// produced this diagnostics object.
        /// </summary>
        public LottieCompositionOptions Options { get; internal set; }

        /// <summary>
        /// An XML representation of the Lottie.
        /// </summary>
        public string LottieXml
        {
            get
            {
                // Convert the XML lazily.
                if (Options.HasFlag(LottieCompositionOptions.DiagnosticsIncludeXml) && _lottieXml == null)
                {
                    _lottieXml = LottieData.Tools.LottieCompositionXmlSerializer.ToXml(LottieComposition).ToString();
                }
                return _lottieXml;
            }
        }

        public string WinCompXml
        {
            get
            {
                // Convert the XML lazily.
                if (Options.HasFlag(LottieCompositionOptions.DiagnosticsIncludeXml) && _winCompXml == null)
                {
                    _winCompXml = WinCompData.Tools.CompositionObjectXmlSerializer.ToXml(RootVisual).ToString();
                }
                return _winCompXml;
            }
        }

        public string WinCompCSharp
        {
            get
            {
                // Generate the C# lazily.
                if (Options.HasFlag(LottieCompositionOptions.DiagnosticsIncludeCSharpGeneratedCode) && _winCompCSharp == null)
                {
                    _winCompCSharp =
                        WinCompData.CodeGen.CompositionObjectFactoryGenerator.CreateFactoryCode(
                            // TODO - generate a name.
                            "MyComposition",
                            RootVisual,
                            (float)LottieComposition.Width,
                            (float)LottieComposition.Height,
                            RootVisual.Properties,
                            LottieToVisualTranslator.ProgressPropertyName,
                            LottieComposition.Duration);
                }
                return _winCompCSharp;
            }
        }

        public KeyValuePair<string, double>[] Markers { get; internal set; } = s_emptyMarkers;

        // Holds the parsed LottieComposition. Only used if one of the codegen or XML options was selected.
        internal LottieData.LottieComposition LottieComposition { get; set; }

        // Holds the translated Visual. Only used if one of the codgen or XML options was selected.
        internal WinCompData.Visual RootVisual { get; set; }

        internal LottieCompositionDiagnostics Clone()
        {
            var result = new LottieCompositionDiagnostics
            {
                Duration = Duration,
                FileName = FileName,
                JsonParsingIssues = JsonParsingIssues,
                LottieComposition = LottieComposition,
                LottieDetails = LottieDetails,
                LottieWidth = LottieWidth,
                LottieHeight = LottieHeight,
                LottieVersion = LottieVersion,
                LottieValidationIssues = LottieValidationIssues,
                _lottieXml = _lottieXml,
                Markers = Markers,
                Options = Options,
                ReadTime = ReadTime,
                RootVisual = RootVisual,
                ParseTime = ParseTime,
                TranslationTime = TranslationTime,
                ValidationTime = ValidationTime,
                InstantiationTime = InstantiationTime,
                TranslationIssues = TranslationIssues,
                _winCompCSharp = _winCompCSharp,
                _winCompXml = _winCompXml,
            };

            return result;
        }
    }
}
