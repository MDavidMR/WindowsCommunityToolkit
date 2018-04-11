namespace LottieData
{
    /// <summary>
    /// Types of <see cref="ShapeLayerContent"/> objects.
    /// </summary>
#if !WINDOWS_UWP
    public
#endif
    enum ShapeContentType
    {
        Group,
        SolidColorStroke,
        LinearGradientStroke,
        RadialGradientStroke,
        SolidColorFill,
        LinearGradientFill,
        RadialGradientFill,
        Transform,
        Path,
        Ellipse,
        Rectangle,
        Polystar,
        TrimPath,
        MergePaths,
        Repeater,
        RoundedCorner,
    }
}
