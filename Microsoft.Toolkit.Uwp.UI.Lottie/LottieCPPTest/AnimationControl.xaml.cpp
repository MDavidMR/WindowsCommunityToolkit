//
// AnimationControl.xaml.cpp
// Implementation of the AnimationControl class
//

#include "pch.h"
#include "AnimationControl.xaml.h"
#include "WindowsNumerics.h"

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

void AnimationControl::OnSizeChanged(Object ^ sender, SizeChangedEventArgs ^ e)
{
    // Rescale whenever control size changes
    ScaleVisual();
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
    Windows::UI::Xaml::Hosting::ElementCompositionPreview::SetElementChildVisual(animationGrid, m_spriteVisual);
    m_spriteVisual->Children->InsertAtTop(m_rootVisual);
    ScaleVisual();
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

void AnimationControl::ScaleVisual()
{
    if ((animationGrid->ActualHeight > 0 || animationGrid->ActualWidth > 0)
        && m_animationLoaded)
    {
        // Basic uniform scale
        float ratioWidth = (float)animationGrid->ActualHeight / m_size.x;
        float ratioHeight = (float)animationGrid->ActualWidth / m_size.y;
        if (ratioWidth < ratioHeight)
            ratioHeight = ratioWidth;
        else
            ratioWidth = ratioHeight;
        m_spriteVisual->Scale = float3{ (float)ratioWidth, (float)ratioHeight, 1 };

        float scaledSizeWidth = (float)m_size.x * ratioWidth;
        float scaledSizeHeight = (float)m_size.y * ratioHeight;
        m_spriteVisual->Size = float2{ scaledSizeWidth, scaledSizeHeight };
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
