#pragma once

#include "CompositionSegment.g.h"

namespace winrt::CompPlayer::implementation
{
    struct CompositionSegment : CompositionSegmentT<CompositionSegment>
    {
        CompositionSegment() = default;

        hstring Name();
        void Name(hstring const& value);
        double FromProgress();
        void FromProgress(double value);
        double ToProgress();
        void ToProgress(double value);
        bool IsLoopingEnabled();
        void IsLoopingEnabled(bool value);
        bool ReverseAnimation();
        void ReverseAnimation(bool value);
    };
}

namespace winrt::CompPlayer::factory_implementation
{
    struct CompositionSegment : CompositionSegmentT<CompositionSegment, implementation::CompositionSegment>
    {
    };
}
