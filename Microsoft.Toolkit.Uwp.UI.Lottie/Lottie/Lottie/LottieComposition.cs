#if DEBUG
// Uncomment this to slow down async awaits for testing.
//#define SlowAwaits
#endif
using LottieData;
using LottieData.Serialization;
using System;
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
        readonly string _applicationUri;
        readonly StorageFile _storageFile;

        /// <summary>
        /// Constructor to allow a <see cref="LottieComposition"/> to be used in markup.
        /// </summary>
        public LottieComposition() { }

        LottieComposition(string applicationUri)
        {
            _applicationUri = applicationUri;
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
        public static LottieComposition CreateFromString(string applicationUri)
        {
            if (!Uri.IsWellFormedUriString(applicationUri, UriKind.RelativeOrAbsolute))
            {
                // TODO - throw?
                return null;
            }
            // TODO - More validation that it's like an application URI so we can fail earlier.

            return new LottieComposition(applicationUri);
        }

        public LottieCompositionOptions Options { get; set; }

        internal override async Task<CompositionLoadResult> TryLoad(Compositor compositor)
        {
            var diagnostics = new LottieCompositionDiagnostics();

            var result = new CompositionLoadResult
            {
                Diagnostics = diagnostics,
            };

            AnimatedComposition animatedComposition = null;

            var file = await GetStorageFileAsync();

            diagnostics.FileName = file.Name;

            var jsonString = file != null
                    ? await FileIO.ReadTextAsync(file)
                    : null;


            if (string.IsNullOrWhiteSpace(jsonString))
            {
                result.LoadSucceeded = true;
                return result;
            }
            else
            {
                var sw = Stopwatch.StartNew();

                // Parsing large Lottie files can take significant time. Do it on
                // another thread.
                LottieData.LottieComposition lottieComposition = null;
                await CheckedAwait(Task.Run(() =>
                {
                    lottieComposition =
                        LottieCompositionJsonReader.ReadLottieCompositionFromJsonString(
                            jsonString,
                            out var readerIssues);

                    diagnostics.JsonParsingIssues = readerIssues;
                }));

                diagnostics.ParseTime = sw.Elapsed;
                sw.Restart();

                if (lottieComposition == null)
                {
                    return result;
                }

                diagnostics.LottieDetails = DescribeLottieComposition(lottieComposition);

                if (Options.HasFlag(LottieCompositionOptions.IncludeXmlToDiagnostics))
                {
                    diagnostics.LottieXml = LottieData.Tools.LottieCompositionXmlSerializer.ToXml(lottieComposition).ToString();
                }

                // Validate the composition and report if issues are found.
                diagnostics.LottieValidationIssues = LottieCompositionValidator.Validate(lottieComposition);

                diagnostics.ValidationTime = sw.Elapsed;
                sw.Restart();

                // Translating large Lotties can take significant time. Do it on another thread.
                WinCompData.Visual newLottieVisual = null;
                bool translateSucceeded = false;
                await CheckedAwait(Task.Run(() =>
                {
                    translateSucceeded = LottieToVisualTranslator.TryTranslateLottieComposition(
                        lottieComposition,
                        compositor,
                        false, // strictTranslation
                        true, // annotate
                        out newLottieVisual,
                        out var translationIssues);

                    diagnostics.TranslationIssues = translationIssues;
                }));

                diagnostics.TranslationTime = sw.Elapsed;
                sw.Restart();

                if (!translateSucceeded)
                {
                    return result;
                }
                else
                {
                    if (Options.HasFlag(LottieCompositionOptions.IncludeXmlToDiagnostics))
                    {
                        diagnostics.WinCompXml = WinCompData.Tools.CompositionObjectXmlSerializer.ToXml(newLottieVisual).ToString();
                    }
                }

                // Instantiate the Composition Visual.
                var newAnimatedCompositionRoot = VisualInstantiator.CreateVisual(compositor, newLottieVisual);

                animatedComposition = new AnimatedComposition(
                    newAnimatedCompositionRoot,
                    newAnimatedCompositionRoot,
                    LottieToVisualTranslator.ProgressPropertyName,
                    lottieComposition.Duration);

                diagnostics.InstantiationTime = sw.Elapsed;
                sw.Restart();
            }

            diagnostics.Duration = animatedComposition.AnimationDuration;

            result.LoadSucceeded = true;
            result.Composition = animatedComposition;
            return result;
        }

        async Task<StorageFile> GetStorageFileAsync()
        {
            return _storageFile != null
                ? _storageFile
                : await StorageFile.GetFileFromApplicationUriAsync(new Uri(_applicationUri));
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

