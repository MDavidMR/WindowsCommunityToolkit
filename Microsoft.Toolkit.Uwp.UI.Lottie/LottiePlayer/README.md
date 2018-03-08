# Introduction 
A preliminary version of a tool that converts AfterEffects Vector Animations to native Windows code, based on Bodymovin and using Composition APIs. 
This tool serves two purposes:
1. Parses BodyMovin JSON to produce a CompostionShape tree which is inserted into your XAML app using a ShapeVisual
2. Serializes said Composition tree into a file (C++/CX for now)

# Getting Started
This is based on new RS4 Composition APIs so please talk to me (sohumc) if your're interested in contributing or consuming.
1.	Installation process: you'll need the latest builds from RS4_Release_Webplat_Dev2 and a Windows SDK >= 17085
2.	Dependencies: all paths are built using a version of Wind2D that implements IGeometrySource2D; you'll need to install this nuget from \\\scratch2\scratch\sohumc_shapes\Win2D
3.	API references: 
The hope is to wrap all of this functionality neatly inside a single XAML UserControl (BMControl.cs), but this work is yet to be completed. For now, take a look at 
MainPage.cs and follow the pattern established there to there to include the animation in your XAML app:

- Create a ShapeVisual
- Create BMComposition.Factory.LoadFileFromUri(ShapeVisual, JsonFilePath)
- ElementCompositionPreview.SetElementChildVisual(XAMLHost, ShapeVisual)
- To Play and Pause Animations, call the relevant methods on your BMComposition object.

# Build and Test
TODO: Describe and show how to build your code and run the tests. 

# Contribute

You will need to be familiar with:

1. The [Composition APIs](https://docs.microsoft.com/en-us/uwp/api/windows.ui.composition) (especially CompositionAnimations and CompositionBrushes)
2. [Proposed RS4 API for ShapeVisual](https://microsoft.visualstudio.com/OS/ft_comp_r/_git/os?path=%2Fonecoreuap%2Fwindows%2Fdwm%2Fdesign%2FShapes%2FShapes.cs&version=GBuser%2Fanchen%2FShapesApiProposal&_a=contents)
3. [Win2D CanvasGeometry](https://microsoft.github.io/Win2D/html/T_Microsoft_Graphics_Canvas_Geometry_CanvasGeometry.htm)
4. [Bodymovin](https://github.com/bodymovin/bodymovin) and its syntax (See: the [Bodymovin Dictionary](https://microsoft.visualstudio.com/DepComposition.Samples/_git/Lottie?_a=preview&path=%2FBodymovinDictionary.md&version=GBmaster))
5. [Lottie-ios](https://github.com/airbnb/lottie-ios), [Lottie-android](https://github.com/airbnb/lottie-android), [Lottie-uwp](https://github.com/azchohfi/LottieUWP/) (an android port from Java so ignore Android-esque oddities)

The high-level design/ plan of action is as follows:

We want the output of the tool to map to the Visual Layer, which means that the precedents from Bodymovin's JSPlayer and Lottie's iOS and Android players will not hold. 
These existing solutions use client-side renderers and animators resulting in sub-optimal performance and complicated tooling. It is our belief/ premise that the UWP is mature enough 
(in terms of feature richness) for the needs of Bodymovin to be met by the Composition APIs (feat. Win2D). 

The hope is to represent AfterEffect KeyFrames and Shape objects as CompositionAnimation keyframes consisting of CompositionShapes. 
The platform APIs should be able to handle all interpolations on properties.  

Here is a proposed mapping of objects:

1. Lottie UserControl Root -> ElementCompositionPreview.SetElementChildVisual(CompositionContainerVisual)
2. Ideally, the entire vector scene can be expressed as a CompositionShapeCollection under a single ShapeVisual
3. We will need separate ShapeVisuals for the following cases:
    - "ddd" : AE 2.5d Matrix4x4 projections
    - "o" : GroupOpacity on an entire Layer that cannot be resolved as opacity on individual brushes
    - shadows?
    - anything else
4. AfterEffects Layer -> ContainerShape
5. Shapes (Ellipse, Rect, RoundedRect, Line, PolyStar, PolyLine, Path) -> SpriteShape w/ one of EllipseGeometry, RoundedRectGeometry, RectangleGeometry, LineGeometry, or PathGeometry
6. PathGeometry to be constructed using Win2D CanvasPathBuilder and wrapped in CompositionPath
7. Content:
    - Color -> CompositionColorBrush
    - LinearGradient -> CompostionLinearGradientBrush
    - RadialGradient -> CompositionSurfaceBrush + Win2D Surface w/ RadialGradient
    - Image -> CompositionSurfaceBrush w/ LoadedImageSurface API
    - Font -> CompositionSpriteShape + Win2D GeometryFromText
8. Mask and Mattes: haven't thought this through 
    - possibly intersection of Geometry between two layers using Win2D CombineGeometry? 
    - possibly CompositionEffectBrush + Composite effect + Composite/BlendModes
    - possible CompositionMaskBrush?
9. Keyframes -> CompositionKeyFrameAnimation
10. Expressions -> CompositionExpressionAnimation
11. Animation Progress, PlayRate -> AnimationControllers 

This info is incomplete and I'll add to it as I get going.


Etiquette: create your own branch off master such as sohumc\AnimationViewFixes and send out PRs or whatever. Process is not really a concern at this point (but it will probably become once we have painful merges).
