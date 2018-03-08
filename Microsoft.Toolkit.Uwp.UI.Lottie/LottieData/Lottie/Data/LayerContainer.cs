using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Lottie.Data
{
    /// <summary>
    /// Owned by a <see cref="LottieComposition"/> or a <see cref="PreCompLayer">. Contains
    /// a list of <see cref="Layer"/> objects. The order of the <see cref="Layer"/>s determines
    /// the order in which they are rendered. <see cref="PreCompLayer"/>s in this container can
    /// be referenced by name from other <see cref="Layer"/>s in the assets of 
    /// the <see cref="LottieComposition"/>.
    /// </summary>
    public sealed class LayerContainer
    {
        readonly Dictionary<int, Layer> _layerIdToLayerMap;

        public LayerContainer(IEnumerable<Layer> layers)
        {
            Debug.Assert(_layerIdToLayerMap == null);
            _layerIdToLayerMap = layers.ToDictionary(layer => layer.Id);
        }

        /// <summary>
        /// Returns the <see cref="Layer"/>s in the <see cref="LayerContainer"/> in
        /// painting order.
        /// </summary>
        public IEnumerable<Layer> GetLayersBottomToTop() => _layerIdToLayerMap.Values.OrderByDescending(layer => layer.Id);
        internal IEnumerable<Layer> GetLayersTopToBottom() => _layerIdToLayerMap.Values.OrderBy(layer => layer.Id);
        /// <summary>
        /// Returns the <see cref="Layer"/> with the given id, or null if no matching <see cref="Layer"/> is found.
        /// </summary>
        public Layer GetLayerById(int? id) => id.HasValue ? _layerIdToLayerMap[id.Value] : null;
        internal Layer GetLayerByName(string name) => 
            name == null 
                ? null 
                : _layerIdToLayerMap.Values.Where(layer => layer.Name == name).FirstOrDefault();
    }
}
