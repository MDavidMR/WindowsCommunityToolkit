#if DEBUG
// Uncomment this to slow down async awaits for testing.
//#define SlowAwaits
#endif
using LottieData;
using LottieData.Serialization;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.Composition;

namespace Lottie
{
    /// <summary>
    /// A <see cref="CompositionPlayerSource"/> for a Lottie composition. This allows
    /// a Lottie to be specified as the source of a <see cref="CompositionPlayerSource"/>.
    /// </summary>
    public sealed class LottieComposition : CompositionPlayerSource
    {
        readonly StorageFile _storageFile;
        WinCompData.Visual _wincompDataRootVisual;
        double _width;
        double _height;
        TimeSpan _duration;
        LottieCompositionDiagnostics _diagnostics;
        TaskCompletionSource<bool> _loadWaiter;

        /// <summary>
        /// Constructor to allow a <see cref="LottieComposition"/> to be used in markup.
        /// </summary>
        public LottieComposition() { }

        LottieComposition(Uri uriSource)
        {
            UriSource = uriSource;
        }

        /// <summary>
        /// Creates a <see cref="CompositionPlayerSource"/> from a <see cref="StorageFile"/>.
        /// </summary>
        public LottieComposition(StorageFile storageFile)
        {
            _storageFile = storageFile;
        }

        /// <summary>
        /// Called by XAML to convert a string to a <see cref="CompositionPlayerSource"/>.
        /// </summary>
        public static LottieComposition CreateFromString(string uri)
        {
            var uriUri = StringToUri(uri);
            if (uriUri == null)
            {
                // TODO - throw?
                return null;
            }
            return new LottieComposition(uriUri);
        }

        /// <summary>
        /// Gets or sets the Uniform Resource Identifier (URI) of the JSON source file that generated this <see cref="LottieComposition"/>.
        /// </summary>
        public Uri UriSource { get; set; }

        public LottieCompositionOptions Options { get; set; }

        internal override async Task<CompositionLoadResult> TryLoad(Compositor compositor)
        {
            // TODO - if the storage file or UriSource are not set, tell the CompositionPlayer to fire a CompositionPlayerFailed event.
            var sw = Stopwatch.StartNew();

            var diagnostics = new LottieCompositionDiagnostics();
            var result = new CompositionLoadResult() { Diagnostics = diagnostics };

            if (_loadWaiter != null)
            {
                // A load has been started. Wait for it and get its results.
                await _loadWaiter.Task;

                // Copy out the diagnostics info from the previous load.
                diagnostics.Duration = _diagnostics.Duration;
                diagnostics.FileName = _diagnostics.FileName;
                diagnostics.JsonParsingIssues = _diagnostics.JsonParsingIssues;
                diagnostics.LottieDetails = _diagnostics.LottieDetails;
                diagnostics.LottieHeight = _diagnostics.LottieHeight;
                diagnostics.LottieValidationIssues = _diagnostics.LottieValidationIssues;
                diagnostics.LottieWidth = _diagnostics.LottieWidth;
                diagnostics.LottieXml = _diagnostics.LottieXml;
                diagnostics.Markers = _diagnostics.Markers;
                diagnostics.ParseTime = _diagnostics.ParseTime;
                diagnostics.TranslationIssues = _diagnostics.TranslationIssues;
                diagnostics.TranslationTime = _diagnostics.TranslationTime;
                diagnostics.ValidationTime = _diagnostics.ValidationTime;
                diagnostics.WinCompCSharp = _diagnostics.WinCompCSharp;
                diagnostics.WinCompXml = _diagnostics.WinCompXml;
            }
            else
            {
                // Create a _loadWaiter for subsequent loads to wait on.
                _loadWaiter = new TaskCompletionSource<bool>();

                // Subsequent loads can use the information out of this diagnostics.
                _diagnostics = diagnostics;

                // Get the file name and contents.
                (var fileName, var jsonString) = await ReadFileAsync();
                diagnostics.FileName = fileName;

                diagnostics.ReadTime = sw.Elapsed;
                sw.Restart();

                // Parsing large Lottie files can take significant time. Do it on
                // another thread.
                LottieData.LottieComposition lottieComposition = null;
                await CheckedAwait(Task.Run(() =>
                {
                    lottieComposition =
                        LottieCompositionJsonReader.ReadLottieCompositionFromJsonString(
                            jsonString,
                            LottieCompositionJsonReader.Options.IgnoreMatchNames,
                            out var readerIssues);

                    diagnostics.JsonParsingIssues = readerIssues;
                }));

                diagnostics.ParseTime = sw.Elapsed;
                sw.Restart();

                if (lottieComposition == null)
                {
                    // Let any future loads use this result.
                    _loadWaiter.TrySetResult(true);
                    return result;
                }

                // For each marker, normalize to a progress value by subtracting the InPoint (so it is relative to the start of the animation)
                // and dividing by OutPoint - InPoint

                diagnostics.LottieDetails = DescribeLottieComposition(lottieComposition);
                diagnostics.Markers = lottieComposition.Markers.Select(m =>
                {
                    // Normalize the marker InPoint value to a progress (0..1) value.
                    var markerProgress = (m.Frame - lottieComposition.InPoint) / (lottieComposition.OutPoint - lottieComposition.InPoint);
                    return new KeyValuePair<string, double>(m.Name, markerProgress);
                }).ToArray();

                diagnostics.LottieWidth = _width = lottieComposition.Width;
                diagnostics.LottieHeight = _height = lottieComposition.Height;
                diagnostics.Duration = _duration = lottieComposition.Duration;

                if (Options.HasFlag(LottieCompositionOptions.IncludeXmlToDiagnostics))
                {
                    diagnostics.LottieXml = LottieData.Tools.LottieCompositionXmlSerializer.ToXml(lottieComposition).ToString();
                }

                // Validate the composition and report if issues are found.
                diagnostics.LottieValidationIssues = LottieCompositionValidator.Validate(lottieComposition);

                diagnostics.ValidationTime = sw.Elapsed;
                sw.Restart();

                // Translating large Lotties can take significant time. Do it on another thread.
                bool translateSucceeded = false;
                await CheckedAwait(Task.Run(() =>
                {
                    translateSucceeded = LottieToVisualTranslator.TryTranslateLottieComposition(
                        lottieComposition,
                        false, // strictTranslation
                        true, // annotate
                        out _wincompDataRootVisual,
                        out var translationIssues);

                    _diagnostics.TranslationIssues = translationIssues;
                }));

                diagnostics.TranslationTime = sw.Elapsed;
                sw.Restart();

                if (!translateSucceeded)
                {
                    // Let any future loads use this result.
                    _loadWaiter.TrySetResult(true);
                    return result;
                }
                else
                {
                    if (Options.HasFlag(LottieCompositionOptions.IncludeXmlToDiagnostics))
                    {
                        diagnostics.WinCompXml = WinCompData.Tools.CompositionObjectXmlSerializer.ToXml(_wincompDataRootVisual).ToString();
                    }

                    if (Options.HasFlag(LottieCompositionOptions.IncludeCSharpGeneratedCode))
                    {
                        diagnostics.WinCompCSharp = WinCompData.CodeGen.CompositionObjectFactoryGenerator.CreateFactoryCode(_wincompDataRootVisual);
                    }
                }

                // Let any future loads use this result.
                _loadWaiter.TrySetResult(true);
            }

            if (_wincompDataRootVisual != null)
            {
                sw.Restart();
                // Instantiate the Composition Visual.
                var visualPlayerRoot = VisualInstantiator.CreateVisual(compositor, _wincompDataRootVisual);

                // Wrap it in a VisualPlayer so that the animations can be played.
                var visualPlayer = new VisualPlayer(
                    visualPlayerRoot,
                    new System.Numerics.Vector2((float)_width, (float)_height),
                    visualPlayerRoot,
                    LottieToVisualTranslator.ProgressPropertyName,
                    _duration);

                diagnostics.InstantiationTime = sw.Elapsed;
                diagnostics.Duration = visualPlayer.AnimationDuration;

                result.LoadSucceeded = true;
                result.VisualPlayer = visualPlayer;
            }
            return result;
        }

        Task<ValueTuple<string, string>> ReadFileAsync()
            => _storageFile != null 
                ? ReadStorageFileAsync(_storageFile) 
                : ReadUriAsync(UriSource);

        async Task<ValueTuple<string, string>> ReadUriAsync(Uri uri)
        {
            var absoluteUri = GetAbsoluteUri(uri);
            if (absoluteUri != null)
            {
                if (absoluteUri.Scheme.StartsWith("ms-"))
                {
                    return await ReadStorageFileAsync(await StorageFile.GetFileFromApplicationUriAsync(absoluteUri));
                }
                else
                {
                    var winrtClient = new Windows.Web.Http.HttpClient();
                    var response = await winrtClient.GetAsync(absoluteUri);
                    var result = await response.Content.ReadAsStringAsync();
                    return ValueTuple.Create(absoluteUri.LocalPath, result);
                }
            }
            return ValueTuple.Create<string, string>(null, null);
        }

        async Task<ValueTuple<string, string>> ReadStorageFileAsync(StorageFile storageFile)
        {
            Debug.Assert(storageFile != null);
            var result = await FileIO.ReadTextAsync(storageFile);
            return ValueTuple.Create(storageFile.Name, result);
        }

        // Creates a string that describes the given LottieComposition for diagnostics purposes.
        static string DescribeLottieComposition(LottieData.LottieComposition lottieComposition)
        {
            int precompLayerCount = 0;
            int solidLayerCount = 0;
            int imageLayerCount = 0;
            int nullLayerCount = 0;
            int shapeLayerCount = 0;
            int textLayerCount = 0;

            // Get the layers stored in assets.
            var layersInAssets =
                from asset in lottieComposition.Assets
                where asset.Type == Asset.AssetType.LayerCollection
                let layerCollection = (LayerCollectionAsset)asset
                from layer in layerCollection.Layers.GetLayersBottomToTop()
                select layer;

            foreach (var layer in lottieComposition.Layers.GetLayersBottomToTop().Concat(layersInAssets))
            {
                switch (layer.Type)
                {
                    case Layer.LayerType.PreComp:
                        precompLayerCount++;
                        break;
                    case Layer.LayerType.Solid:
                        solidLayerCount++;
                        break;
                    case Layer.LayerType.Image:
                        imageLayerCount++;
                        break;
                    case Layer.LayerType.Null:
                        nullLayerCount++;
                        break;
                    case Layer.LayerType.Shape:
                        shapeLayerCount++;
                        break;
                    case Layer.LayerType.Text:
                        textLayerCount++;
                        break;
                    default:
                        throw new InvalidOperationException();
                }
            }

            return $"LottieComposition w={lottieComposition.Width} h={lottieComposition.Height} " +
                $"layers: precomp={precompLayerCount} solid={solidLayerCount} image={imageLayerCount} null={nullLayerCount} shape={shapeLayerCount} text={textLayerCount}";
        }

        // Parses a string into an absolute URI, or null if the string is malformed.
        static Uri StringToUri(string uri)
        {
            if (!Uri.IsWellFormedUriString(uri, UriKind.RelativeOrAbsolute))
            {
                return null;
            }

            return GetAbsoluteUri(new Uri(uri, UriKind.RelativeOrAbsolute));
        }

        // Returns an absolute URI. Relative URIs are made relative to ms-appx:///
        static Uri GetAbsoluteUri(Uri uri)
        {
            if (uri == null)
            {
                return null;
            }

            if (uri.IsAbsoluteUri)
            {
                return uri;
            }

            return new Uri($"ms-appx:///{uri}", UriKind.Absolute);
        }

        #region DEBUG
        // For testing purposes, slows down a task.
#if SlowAwaits
        const int _checkedDelayMs = 5;
        async
#endif
        Task CheckedAwait(Task task)
        {
#if SlowAwaits
            await Task.Delay(_checkedDelayMs);
            await task;
            await Task.Delay(_checkedDelayMs);
#else
            return task;
#endif
        }
        #endregion DEBUG
    }

}

