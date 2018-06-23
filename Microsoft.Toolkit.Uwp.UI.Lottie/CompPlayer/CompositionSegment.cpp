#include "pch.h"
#include "CompositionSegment.h"

namespace winrt::CompPlayer::implementation
{
    hstring CompositionSegment::Name()
    {
        return L"TODO";
    }

    void CompositionSegment::Name(hstring const& value)
    {
        throw hresult_not_implemented();
    }

    double CompositionSegment::FromProgress()
    {
        // TODO
        return 0;
    }

    void CompositionSegment::FromProgress(double value)
    {
        throw hresult_not_implemented();
    }

    double CompositionSegment::ToProgress()
    {
        // TODO
        return 0;
    }

    void CompositionSegment::ToProgress(double value)
    {
        throw hresult_not_implemented();
    }

    bool CompositionSegment::IsLoopingEnabled()
    {
        // TODO
        return false;
    }

    void CompositionSegment::IsLoopingEnabled(bool value)
    {
        throw hresult_not_implemented();
    }

    bool CompositionSegment::ReverseAnimation()
    {
        // TODO
        return false;
    }

    void CompositionSegment::ReverseAnimation(bool value)
    {
        throw hresult_not_implemented();
    }
}
