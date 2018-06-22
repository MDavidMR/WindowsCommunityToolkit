#include "pch.h"
#include "CompositionPlayer.h"

namespace winrt::CompPlayer::implementation
{
    Windows::Foundation::IInspectable CompositionPlayer::Diagnostics()
    {
        // TODO: support Diagnostics object.
        return nullptr;
    }

    Windows::Foundation::TimeSpan CompositionPlayer::Duration()
    {
        // TODO: Return the correct value.
        return Windows::Foundation::TimeSpan{ 1L };
    }

    CompPlayer::ICompositionSource CompositionPlayer::Source()
    {
        // TODO
        return nullptr;
    }

    void CompositionPlayer::Source(CompPlayer::ICompositionSource const& value)
    {
        // TODO
    }

    double CompositionPlayer::FromProgress()
    {
        // TODO
        return 0;
    }

    void CompositionPlayer::FromProgress(double value)
    {
        throw hresult_not_implemented();
    }

    double CompositionPlayer::ToProgress()
    {
        // TODO
        return 0;
    }

    void CompositionPlayer::ToProgress(double value)
    {
        throw hresult_not_implemented();
    }

    bool CompositionPlayer::AutoPlay()
    {
        // TODO
        return true;
    }

    void CompositionPlayer::AutoPlay(bool value)
    {
        throw hresult_not_implemented();
    }

    bool CompositionPlayer::IsCompositionLoaded()
    {
        // TODO:
        return true;
    }

    bool CompositionPlayer::IsLoopingEnabled()
    {
        // TODO
        return true;
    }

    void CompositionPlayer::IsLoopingEnabled(bool value)
    {
        throw hresult_not_implemented();
    }

    bool CompositionPlayer::IsPlaying()
    {
        // TODO
        return true;
    }

    bool CompositionPlayer::ReverseAnimation()
    {
        // TODO
        return false;
    }

    double CompositionPlayer::PlaybackRate()
    {
        // TODO
        return 1;
    }

    void CompositionPlayer::PlaybackRate(double value)
    {
        throw hresult_not_implemented();
    }

    Windows::UI::Composition::CompositionObject CompositionPlayer::ProgressObject()
    {
        // TODO
        return nullptr;
    }

    Windows::UI::Color CompositionPlayer::BackgroundColor()
    {
        // TODO
        return Windows::UI::Colors::White();
    }

    void CompositionPlayer::BackgroundColor(Windows::UI::Color const& value)
    {
        throw hresult_not_implemented();
    }

    Windows::UI::Xaml::Media::Stretch CompositionPlayer::Stretch()
    {
        // TODO
        return Windows::UI::Xaml::Media::Stretch::UniformToFill;
    }

    void CompositionPlayer::Stretch(Windows::UI::Xaml::Media::Stretch const& value)
    {
        throw hresult_not_implemented();
    }

    void CompositionPlayer::Pause()
    {
        throw hresult_not_implemented();
    }

    void CompositionPlayer::Play()
    {
        throw hresult_not_implemented();
    }

    Windows::Foundation::IAsyncAction CompositionPlayer::PlayAsync()
    {
        throw hresult_not_implemented();
    }

    Windows::Foundation::IAsyncAction CompositionPlayer::PlayAsync(CompPlayer::CompositionSegment const& segment)
    {
        throw hresult_not_implemented();
    }

    void CompositionPlayer::Resume()
    {
        throw hresult_not_implemented();
    }

    void CompositionPlayer::SetProgress(double progress)
    {
        throw hresult_not_implemented();
    }

    void CompositionPlayer::Stop()
    {
        throw hresult_not_implemented();
    }
}
