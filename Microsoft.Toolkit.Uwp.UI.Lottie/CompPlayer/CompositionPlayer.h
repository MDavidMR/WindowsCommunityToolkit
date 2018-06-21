#pragma once

#include "CompositionPlayer.g.h"

namespace winrt::CompPlayer::implementation
{
    struct CompositionPlayer : CompositionPlayerT<CompositionPlayer>
    {
        CompositionPlayer() = default;

        Windows::Foundation::IInspectable Diagnostics();
        Windows::Foundation::TimeSpan Duration();
        CompPlayer::CompositionSource Source();
        void Source(CompPlayer::CompositionSource const& value);
        double FromProgress();
        void FromProgress(double value);
        double ToProgress();
        void ToProgress(double value);
        bool AutoPlay();
        void AutoPlay(bool value);
        bool IsCompositionLoaded();
        bool IsLoopingEnabled();
        void IsLoopingEnabled(bool value);
        bool IsPlaying();
        bool ReverseAnimation();
        double PlaybackRate();
        void PlaybackRate(double value);
        Windows::UI::Composition::CompositionObject ProgressObject();
        Windows::UI::Color BackgroundColor();
        void BackgroundColor(Windows::UI::Color const& value);
        Windows::UI::Xaml::Media::Stretch Stretch();
        void Stretch(Windows::UI::Xaml::Media::Stretch const& value);
        void Pause();
        void Play();
        Windows::Foundation::IAsyncAction PlayAync();
        Windows::Foundation::IAsyncAction PlayAync(CompPlayer::CompositionSegment const& segment);
        void Resume();
        void SetProgress(double progress);
        void Stop();
    };
}

namespace winrt::CompPlayer::factory_implementation
{
    struct CompositionPlayer : CompositionPlayerT<CompositionPlayer, implementation::CompositionPlayer>
    {
    };
}
