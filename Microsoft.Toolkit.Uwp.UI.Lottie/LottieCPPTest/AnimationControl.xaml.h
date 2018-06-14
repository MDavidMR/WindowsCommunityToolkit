//
// AnimationControl.xaml.h
// Declaration of the AnimationControl class
//

#pragma once

#include "AnimationControl.g.h"
#include "ICompositionSource.h"

namespace LottieCPPTest
{
    [Windows::Foundation::Metadata::WebHostHidden]
    public ref class AnimationControl sealed
    {
    public:
        AnimationControl();
        virtual ~AnimationControl();
        bool LoadAnimation(Compositions::ICompositionSource^ composition);
        void PlayAnimationFrames(float startFrame, float endFrame, float totalFrames, bool reversePlayback, Windows::UI::Composition::AnimationIterationBehavior iterationBehavior);
        void PlayAnimation(bool reversePlayback, Windows::UI::Composition::AnimationIterationBehavior iterationBehavior);
        void Pause();
    protected:
        virtual Windows::Foundation::Size MeasureOverride(Windows::Foundation::Size availableSize) override;
        virtual Windows::Foundation::Size ArrangeOverride(Windows::Foundation::Size finalSize) override;
    private:
        void PlayAnimationInternal(float start, float stop, Windows::Foundation::TimeSpan duration, Windows::UI::Composition::AnimationIterationBehavior iterationBehavior);

        // Playback
        Windows::UI::Composition::SpriteVisual^ m_spriteVisual;
        Windows::UI::Composition::CompositionEasingFunction^ m_linearEasingFunction;
        Windows::UI::Composition::ScalarKeyFrameAnimation^ m_playAnimation;
        bool m_animationLoaded;

        // ICompositionSource
        Windows::UI::Composition::Compositor^ m_compositor;
        Windows::UI::Composition::Visual^ m_rootVisual;
        Windows::Foundation::Numerics::float2 m_size;
        Windows::UI::Composition::CompositionPropertySet^ m_progressPropertySet;
        Windows::Foundation::TimeSpan m_duration;
        Platform::Object^ m_diagnostics;
    };
}
