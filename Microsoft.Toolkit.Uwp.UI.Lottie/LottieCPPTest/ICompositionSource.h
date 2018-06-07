#pragma once
namespace Compositions
{
    public interface class ICompositionSource
    {
        virtual bool TryCreateInstance(
            Windows::UI::Composition::Compositor^ compositor,
            Windows::UI::Composition::Visual^* rootVisual,
            Windows::Foundation::Numerics::float2* size,
            Windows::UI::Composition::CompositionPropertySet^* progressPropertySet,
            Windows::Foundation::TimeSpan* duration,
            Platform::Object^* diagnostics);
    };
}

