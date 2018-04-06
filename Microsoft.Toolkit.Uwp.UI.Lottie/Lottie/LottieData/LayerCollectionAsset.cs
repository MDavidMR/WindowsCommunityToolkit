﻿namespace LottieData
{
#if !WINDOWS_UWP
    public
#endif
    sealed class LayerCollectionAsset : Asset
    {
        public LayerCollectionAsset(string id, LayerCollection layers) : base(id)
        {
            Layers = layers;
        }

        public LayerCollection Layers { get; }

        public override AssetType Type => AssetType.LayerCollection;
    }
}
