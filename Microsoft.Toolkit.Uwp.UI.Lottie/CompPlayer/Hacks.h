#pragma once
#include <winrt\base.h>

#include <winrt\Windows.UI.Xaml.Hosting.h>

namespace winrt
{
    using namespace Windows::UI::Xaml;
    using namespace Windows::UI::Xaml::Hosting;
    using namespace Windows::Foundation;
    using namespace Windows::UI::Composition;
    using namespace Windows::UI::Xaml::Media;
    using namespace Windows::Foundation::Numerics;
}

using std::wstring_view;

inline winrt::DependencyProperty InitializeDependencyProperty(
    wstring_view const& propertyNameString,
    wstring_view const& propertyTypeNameString,
    wstring_view const& ownerTypeNameString,
    bool isAttached,
    winrt::IInspectable defaultValue,
    winrt::PropertyChangedCallback propertyChangedCallback = nullptr)
{
    auto propertyType = winrt::Interop::TypeName();
    propertyType.Name = propertyTypeNameString;
    propertyType.Kind = winrt::Interop::TypeKind::Metadata;

    auto ownerType = winrt::Interop::TypeName();
    ownerType.Name = ownerTypeNameString;
    ownerType.Kind = winrt::Interop::TypeKind::Metadata;

    auto propertyMetadata = winrt::PropertyMetadata(defaultValue, propertyChangedCallback);

    if (isAttached)
    {
        return winrt::DependencyProperty::RegisterAttached(propertyNameString, propertyType, ownerType, propertyMetadata);
    }
    else
    {
        return winrt::DependencyProperty::Register(propertyNameString, propertyType, ownerType, propertyMetadata);
    }
}


// Copied from CastHelpers.h
template <typename T, typename U>
T safe_cast(const U& value)
{
    if (value)
    {
        return value.as<T>();
    }
    return nullptr;
}

template <typename T, typename U>
T safe_try_cast(const U& value)
{
    if (value)
    {
        return value.try_as<T>();
    }
    return nullptr;
}

struct auto_cast
{
    explicit auto_cast(winrt::IInspectable const& value) : m_value(value)
    {
    }

    template <typename T>
    operator T() const
    {
        return safe_cast<T>(m_value);
    }

private:
    winrt::IInspectable const& m_value;
};