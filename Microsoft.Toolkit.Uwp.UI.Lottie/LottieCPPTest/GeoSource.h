//------------------------------------------------------------------------------
//
// Copyright (C) Microsoft. All rights reserved.
//
//------------------------------------------------------------------------------

#pragma once
#include <Windows.Graphics.Interop.h>
#include "d2d1.h"
#include <d2d1_1.h>
#include <d2d1helper.h>

class GeoSource :
    public ABI::Windows::Graphics::IGeometrySource2D,
    public ABI::Windows::Graphics::IGeometrySource2DInterop
{
public:
    GeoSource(
        _In_ ID2D1Geometry* pGeometry)
        : m_cRef(0)
        , m_cpGeometry(pGeometry)
    {
    }

protected:
    ~GeoSource() = default;

public:
    // IUnknown
    IFACEMETHODIMP QueryInterface(
        _In_ REFIID iid,
        _Outptr_opt_ void ** ppvObject) override
    {
        if (iid == __uuidof(IUnknown))
        {
            AddRef();
            *ppvObject = (IUnknown*)(ABI::Windows::Graphics::IGeometrySource2D*) this;
            return S_OK;
        }
        if (iid == __uuidof(IInspectable))
        {
            AddRef();
            *ppvObject = (IInspectable*)(ABI::Windows::Graphics::IGeometrySource2D*) this;
            return S_OK;
        }
        if (iid == __uuidof(ABI::Windows::Graphics::IGeometrySource2D))
        {
            AddRef();
            *ppvObject = (ABI::Windows::Graphics::IGeometrySource2D*) this;
            return S_OK;
        }
        if (iid == __uuidof(ABI::Windows::Graphics::IGeometrySource2DInterop))
        {
            AddRef();
            *ppvObject = (ABI::Windows::Graphics::IGeometrySource2DInterop*) this;
            return S_OK;
        }

        return E_NOINTERFACE;
    }

    IFACEMETHODIMP_(ULONG) AddRef() override
    {
        return InterlockedIncrement(&m_cRef);
    }

    IFACEMETHODIMP_(ULONG) Release() override
    {
        ULONG cRef = InterlockedDecrement(&m_cRef);
        if (0 == cRef)
        {
            delete this;
        }

        return cRef;
    }

    // IInspectable
    IFACEMETHODIMP GetIids(
        _Out_ ULONG * iidCount,
        _When_(*iidCount == 0, _At_(*iids, _Post_null_)) _When_(*iidCount > 0, _At_(*iids, _Post_notnull_)) _Outptr_result_buffer_maybenull_(*iidCount) IID ** iids) override
    {
        *iidCount = 0;
        *iids = nullptr;
        return E_NOTIMPL;
    }

    IFACEMETHODIMP GetRuntimeClassName(
        _Out_ HSTRING * runtimeName) override
    {
        static const WCHAR wszString[] = L"GeoSource";
        HSTRING hstring;
        WindowsCreateString(wszString, _countof(wszString), &hstring);
        *runtimeName = hstring;
        return S_OK;
    }

    IFACEMETHODIMP GetTrustLevel(
        _Out_ TrustLevel* trustLvl) override
    {
        *trustLvl = BaseTrust;
        return S_OK;
    }

    // Windows::Graphics::IGeometrySource2DInterop
    IFACEMETHODIMP GetGeometry(
        _COM_Outptr_ ID2D1Geometry** value) override
    {
        *value = m_cpGeometry.Get();
        (*value)->AddRef();
        return S_OK;
    }

    IFACEMETHODIMP TryGetGeometryUsingFactory(
        _In_ ID2D1Factory* /* factory */,
        _COM_Outptr_result_maybenull_ ID2D1Geometry** value) override
    {
        *value = nullptr;
        return S_OK;
    }

private:
    ULONG m_cRef;
    Microsoft::WRL::ComPtr<ID2D1Geometry> m_cpGeometry;
};