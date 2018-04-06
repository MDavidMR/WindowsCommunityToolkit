using System.Collections.Generic;
using System.Linq;

namespace LottieData
{
    /// <summary>
    /// Validates a <see cref="LottieComposition"/> against various rules.
    /// </summary>
#if !WINDOWS_UWP
    public
#endif
    sealed class LottieCompositionValidator
    {
        readonly LottieComposition _lottieComposition;
        readonly List<string> _issues = new List<string>();

        LottieCompositionValidator(LottieComposition lottieComposition)
        {
            _lottieComposition = lottieComposition;
        }

        /// <summary>
        /// Validates the given <see cref="LottieComposition"/> against all of the validation rules.
        /// Returns a list of validation issues, or an empty list if no issues were found.
        /// </summary>
        public static string[] Validate(LottieComposition lottieComposition)
        {
            var validator = new LottieCompositionValidator(lottieComposition);

            validator.ValidateParentIdPointsToValidLayer();
            validator.ValidateNoParentIdCycles();
            return validator._issues.ToArray();
        }

        /// <summary>
        /// Validates that there are no cycles caused by ParentId references.
        /// </summary>
        void ValidateNoParentIdCycles()
        {
            ValidateNoParentIdCycles(_lottieComposition.Layers);
            foreach (var layersAsset in _lottieComposition.Assets.OfType<LayerCollectionAsset>())
            {
                ValidateNoParentIdCycles(layersAsset.Layers);
            }
        }

        /// <summary>
        /// Validates that there are no cycles caused by ParentId references.
        /// </summary>
        void ValidateNoParentIdCycles(LayerCollection layers)
        {
            // Holds the layers that are known to not be in a cycle.
            var notInCycles = new HashSet<Layer>();
            // Holds the layers that have parents and have not yet been proven to
            // not be in a cycle.
            var maybeInCycles = new HashSet<Layer>();

            // Divide each layer into either notIn a cycle, or maybeIn a cycle.
            foreach (var layer in layers.GetLayersBottomToTop())
            {
                if (layer.ParentId == null)
                {
                    // A layer with no ParentId is definitely notIn a cycle.
                    notInCycles.Add(layer);
                }
                else if (notInCycles.Contains(layers.GetLayerById(layer.ParentId)))
                {
                    // The layer has a parent that is not in a cycle, so the layer is
                    // not in a cycle.
                    notInCycles.Add(layer);
                }
                else
                {
                    // The layer may be in a cycle.
                    maybeInCycles.Add(layer);
                }
            }

            // Keep removing maybeIns that are parented by notIns until there are no more that
            // can be removed.
            do
            {
                foreach (var layer in maybeInCycles)
                {
                    if (notInCycles.Contains(layers.GetLayerById(layer.ParentId)))
                    {
                        // The layer has a parent that is not in a cycle, so the layer
                        // is not in a cycle.
                        notInCycles.Add(layer);
                    }
                }
                // Remove the maybeIns that have now been discovered to be notIns.
                // If at least one layer was discovered to be notIn, keep going.
            } while (maybeInCycles.RemoveWhere(layer => notInCycles.Contains(layer)) != 0);

            // No more notIns were discovered. All the maybeIns are definitely in cycles.
            foreach (var layer in maybeInCycles)
            {
                _issues.Add(@"Layer with ParentId {layer.ParentId} is in a cycle.");
            }
        }

        /// <summary>
        /// Validates that all the ParentId references are either null or refer to a layer in the same collection.
        /// </summary>
        void ValidateParentIdPointsToValidLayer()
        {
            ValidateParentIdPointsToValidLayer(_lottieComposition.Layers);
            foreach (var layersAsset in _lottieComposition.Assets.OfType<LayerCollectionAsset>())
            {
                ValidateNoParentIdCycles(layersAsset.Layers);
            }
        }

        /// <summary>
        /// Validates that all the ParentId references are either null or refer to a layer in the same collection.
        /// </summary>
        void ValidateParentIdPointsToValidLayer(LayerCollection layers)
        {
            foreach (var layer in layers.GetLayersBottomToTop())
            {
                if (layer.ParentId.HasValue && layers.GetLayerById(layer.ParentId) == null)
                {
                    _issues.Add(@"Layer ParentId {layer.ParentId} is invalid.");
                }
            }
        }
    }

}
