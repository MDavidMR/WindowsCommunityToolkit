namespace Lottie.Data
{
    public sealed class AnimatableTransform : ShapeLayerContent
    {
        public AnimatableTransform(
            AnimatableVector2 anchor,
            AnimatableVector2 position,
            AnimatableVector2 scale,
            AnimatableValue<float> rotation,
            AnimatableValue<float> opacity)
            : base("")
        {
            Anchor = anchor;
            Position = position;
            Scale = scale;
            Rotation = rotation;
            Opacity = opacity;
            //StartOpacity = startOpacity;
            //EndOpacity = endOpacity;
        }

        public AnimatableVector2 Anchor { get; }

        public AnimatableVector2 Position { get; }

        public AnimatableVector2 Scale { get; }

        public AnimatableValue<float> Rotation { get; }

        internal AnimatableValue<float> Opacity { get; }

        public override ShapeContentType ContentType => ShapeContentType.Transform;


        // Used for repeaters 
        //internal virtual AnimatableFloat StartOpacity { get; }
        //internal virtual AnimatableFloat EndOpacity { get; }
    }
}