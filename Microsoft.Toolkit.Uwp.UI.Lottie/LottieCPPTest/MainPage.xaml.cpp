//
// MainPage.xaml.cpp
// Implementation of the MainPage class.
//

#include "pch.h"
#include "MainPage.xaml.h"
#include "MyComposition.h"
#include "AnimationControl.xaml.h"

using namespace LottieCPPTest;
using namespace Compositions;
using namespace Platform;
using namespace Windows::UI::Composition;
using namespace Windows::UI::Xaml;

MainPage::MainPage()
{
    InitializeComponent();
}

void MainPage::Page_Loaded(Object^ sender, RoutedEventArgs^ e)
{
    anim->LoadAnimation(ref new MyComposition());
    anim->PlayAnimation(false, AnimationIterationBehavior::Forever);

    anim2->LoadAnimation(ref new MyComposition());
    anim2->PlayAnimation(false, AnimationIterationBehavior::Forever);

    anim3->LoadAnimation(ref new MyComposition());
    anim3->PlayAnimation(false, AnimationIterationBehavior::Forever);
}
