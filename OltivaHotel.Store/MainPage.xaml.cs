using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using OltivaHotel.PCL.Model;
using OltivaHotel.PCL.ViewModel;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace OltivaHotel.Store
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
        
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void CallReceptionClick(object sender, RoutedEventArgs e)
        {

        }

        private void EmailReceptionClick(object sender, RoutedEventArgs e)
        {

        }

        private void CallRoomServiceClick(object sender, RoutedEventArgs e)
        {

        }

        private void MenuNavigationClicked(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof (MenuPage));
        }

        private void CancelClick(object sender, RoutedEventArgs e)
        {
            TodaysSpecialGridView.SelectedItem = null;
            TodaysSpecialGridView.SelectedIndex = -1;
            PopupGrid.Visibility = Visibility.Collapsed;
        }

        private void AddClick(object sender, RoutedEventArgs e)
        {
            TodaysSpecialGridView.SelectedItem = null;
            TodaysSpecialGridView.SelectedIndex = -1;
            PopupGrid.Visibility = Visibility.Collapsed;
        }

    }
}
