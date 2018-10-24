// Copyright(c) Microsoft Corporation.All rights reserved.
// Licensed under the MIT License.

using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using NavigationView = Windows.UI.Xaml.Controls.NavigationView;
using NavigationViewItem = Windows.UI.Xaml.Controls.NavigationViewItem;

namespace LottieTest
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        void NavView_ItemInvoked(NavigationView sender, Windows.UI.Xaml.Controls.NavigationViewItemInvokedEventArgs args)
        {
            var item = sender.MenuItems.OfType<NavigationViewItem>().First(x => (string)x.Content == (string)args.InvokedItem);
            switch (item.Tag)
            {
                case "AuditCorpus":
                    ContentFrame.Navigate(typeof(AuditCorpus));
                    break;
                case "ScrapeLottieFiles":
                    ContentFrame.Navigate(typeof(LottieFilesScraper));
                    break;
                case "ScrapeRewards":
                    ContentFrame.Navigate(typeof(RewardsScraper));
                    break;
                case "MyComposition":
                    ContentFrame.Navigate(typeof(MyComposition));
                    break;
                case "RewardsApp":
                    ContentFrame.Navigate(typeof(RewardsApp));
                    break;
                case "LargeComposition":
                    ContentFrame.Navigate(typeof(LargeComposition));
                    break;
                case "LoadingPerfExerciser":
                    ContentFrame.Navigate(typeof(LoadingPerfExerciser));
                    break;
                default:
                    throw new InvalidOperationException();
            }
        }


        // Test reparenting of the player.
        AnimatedVisualPlayer m_player;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (TheBorder.Child != null)
            {
                m_player = (AnimatedVisualPlayer)TheBorder.Child;
                TheBorder.Child = null;
            }
            else
            {
                TheBorder.Child = m_player;
                m_player = null;
            }
        }
    }
}