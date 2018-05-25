//
// MainPage.xaml.cpp
// Implementation of the MainPage class.
//

#include "pch.h"
#include "MainPage.xaml.h"
#include "MyComposition.cpp"
#include "AnimationControl.xaml.h"

using namespace LottieCPPTest;
using namespace Compositions;
using namespace Platform;
using namespace Windows::UI::Xaml;

MainPage::MainPage()
{
    InitializeComponent();
}

void MainPage::Page_Loaded(Object^ sender, RoutedEventArgs^ e)
{
    anim->LoadAnimation(ref new _0351_pink_drink_machine);
    anim->PlayAnimation(false, AnimationIterationBehavior::Forever);
}
