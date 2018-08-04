// Copyright(c) Microsoft Corporation.All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;

namespace LottieData.Tools
{
    /// <summary>
    /// Calculates stats for a <see cref="LottieComposition"/>.
    /// </summary>
#if !WINDOWS_UWP
    public
#endif
    sealed class Stats
    {
        readonly Version _version;
        readonly string _name;
        readonly double _width;
        readonly double _height;
        readonly int _preCompLayerCount;
        readonly int _solidLayerCount;
        readonly int _imageLayerCount;
        readonly int _nullLayerCount;
        readonly int _shapeLayerCount;
        readonly int _textLayerCount;

        // Creates a string that describes the Lottie.
        public Stats(LottieComposition lottieComposition)
        {
            if (lottieComposition == null) { return; }

            _name = lottieComposition.Name;
            _version = lottieComposition.Version;
            _width = lottieComposition.Width;
            _height = lottieComposition.Height;

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
                        _preCompLayerCount++;
                        break;
                    case Layer.LayerType.Solid:
                        _solidLayerCount++;
                        break;
                    case Layer.LayerType.Image:
                        _imageLayerCount++;
                        break;
                    case Layer.LayerType.Null:
                        _nullLayerCount++;
                        break;
                    case Layer.LayerType.Shape:
                        _shapeLayerCount++;
                        break;
                    case Layer.LayerType.Text:
                        _textLayerCount++;
                        break;
                    default:
                        throw new InvalidOperationException();
                }
            }
        }

        public int PreCompLayerCount => _preCompLayerCount;
        public int SolidLayerCount => _solidLayerCount;
        public int ImageLayerCount => _imageLayerCount;
        public int NullLayerCount => _nullLayerCount;
        public int ShapeLayerCount => _shapeLayerCount;
        public int TextLayerCount => _textLayerCount;
        public double Width => _width;
        public double Height => _height;
        public string Name => _name;
        public Version Version => _version;
    }
}
