//
// AnimationControl.xaml.cpp
// Implementation of the AnimationControl class
//

#include "pch.h"
#include "AnimationControl.xaml.h"
#include "WindowsNumerics.h"

#ifdef max
#undef max
#endif

using namespace LottieCPPTest;
using namespace Compositions;
using namespace Platform;
using namespace Windows::Foundation;
using namespace Windows::Foundation::Numerics;
using namespace Windows::UI::Xaml;
using namespace Windows::UI::Composition;

AnimationControl::AnimationControl()
{
    InitializeComponent();
    m_animationLoaded = false;
}

AnimationControl::~AnimationControl()
{
}

static double AbstractInfinity(double value)
{
    if (value == std::numeric_limits<double>::infinity())
    {
        return std::numeric_limits<double>::max();
    }
    else
    {
        return value;
    }
}

static bool isInfinity(double value)
{
    return (value == std::numeric_limits<double>::infinity());
}

Size AnimationControl::MeasureOverride(Size availableSize)
{
    Size measuredSize;
    double epsilon = std::numeric_limits<double>::epsilon();

    if (!m_animationLoaded || m_size == float2::zero())
    {
        measuredSize = Size((float)epsilon, (float)epsilon);
        return measuredSize;
    }

    auto widthScale = AbstractInfinity(availableSize.Width) / m_size.x;
    auto heightScale = AbstractInfinity(availableSize.Height) / m_size.y;

    // Uniform
    if (heightScale > widthScale)
    {
        measuredSize = Size(availableSize.Width, (float)(m_size.y * widthScale));
    }
    else
    {
        measuredSize = Size((float)(m_size.x * heightScale), availableSize.Height);
    }

    return measuredSize;
}

Size AnimationControl::ArrangeOverride(Size finalSize)
{
    if (!m_animationLoaded || m_size == float2::zero())
    {
        return finalSize;
    }

    auto widthScale = AbstractInfinity(finalSize.Width) / m_size.x;
    auto heightScale = AbstractInfinity(finalSize.Height) / m_size.y;
    if (widthScale < heightScale)
    {
        heightScale = widthScale;
    }
    else
    {
        widthScale = heightScale;
    }
    auto scaledSizeWidth = m_size.x * widthScale;
    auto scaledSizeHeight = m_size.y * heightScale;

    m_spriteVisual->Scale = float3{ (float)widthScale, (float)heightScale, 1 };
    m_spriteVisual->Size = float2{
        std::min<float>((float)(finalSize.Width / widthScale), m_size.x),
        std::min<float>((float)(finalSize.Height / heightScale), m_size.y)};

    auto xOffset = (finalSize.Width - scaledSizeWidth) / 2;
    auto yOffset = (finalSize.Height - scaledSizeHeight) / 2;
    m_spriteVisual->Offset = float3{ (float)xOffset, (float)yOffset, 0 };
    m_spriteVisual->Clip->Offset = float2::zero();

    return finalSize;
}

bool AnimationControl::LoadAnimation(ICompositionSource^ compositionFactory)
{
    m_compositor = Window::Current->Compositor;
    m_linearEasingFunction = m_compositor->CreateLinearEasingFunction();

    auto result = compositionFactory->TryCreateInstance(m_compositor, &m_rootVisual, &m_size, &m_progressPropertySet, &m_duration, &m_diagnostics);
    if (!result)
    {
        return false;
    }
    m_animationLoaded = true;
    m_spriteVisual = m_compositor->CreateSpriteVisual();
    auto clip = m_compositor->CreateInsetClip();
    m_spriteVisual->Clip = clip;
    Windows::UI::Xaml::Hosting::ElementCompositionPreview::SetElementChildVisual(animationGrid, m_spriteVisual);
    m_spriteVisual->Children->InsertAtTop(m_rootVisual);

    // With the new animation, we need to remeasure
    this->InvalidateMeasure();

    return true;
}

void AnimationControl::Pause()
{
    auto controller = m_progressPropertySet->TryGetAnimationController("Progress");
    if (controller)
    {
        controller->Pause();
    }
}

void AnimationControl::PlayAnimationFrames(float startFrame, float endFrame, float totalFrames, bool reversePlayback, AnimationIterationBehavior iterationBehavior)
{
    float firstFrame;
    float secondFrame;
    TimeSpan duration = { (long long)((endFrame - startFrame) / 60) * 10000000 };

    if (reversePlayback)
    {
        firstFrame = endFrame / totalFrames;
        secondFrame = startFrame / totalFrames;
    }
    else
    {
        firstFrame = startFrame / totalFrames;
        secondFrame = endFrame / totalFrames;
    }

    PlayAnimationInternal(firstFrame, secondFrame, duration, iterationBehavior);
}

void AnimationControl::PlayAnimation(bool reversePlayback, AnimationIterationBehavior iterationBehavior)
{
    if (reversePlayback)
    {
        PlayAnimationInternal(1, 0, m_duration, iterationBehavior);
    }
    else
    {
        PlayAnimationInternal(0, 1, m_duration, iterationBehavior);
    }
}

void AnimationControl::PlayAnimationInternal(float start, float stop, TimeSpan duration, AnimationIterationBehavior iterationBehavior)
{
    m_progressPropertySet->InsertScalar("Progress", 0);
    m_playAnimation = m_compositor->CreateScalarKeyFrameAnimation();
    m_playAnimation->Duration = duration;
    m_playAnimation->InsertKeyFrame(0, start);
    m_playAnimation->InsertKeyFrame(1, stop, m_linearEasingFunction);
    m_playAnimation->IterationBehavior = iterationBehavior;
    m_progressPropertySet->StartAnimation("Progress", m_playAnimation);
}
