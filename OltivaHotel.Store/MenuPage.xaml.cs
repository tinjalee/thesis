using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using OltivaHotel.PCL.Model;
using OltivaHotel.PCL.ViewModel;
using OltivaHotel.Store.Common;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace OltivaHotel.Store
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class MenuPage : OltivaHotel.Store.Common.LayoutAwarePage
    {
        private MenuViewModel menuViewModel;

        public MenuPage()
        {
            this.InitializeComponent();
            menuViewModel = (MenuViewModel)DataContext;
        }

        private void MenuPageLoaded(object sender, RoutedEventArgs e)
        {
            OrderListView.ItemsSource = MessageService.StaticMenuItemList;
            GroupedMenuItems.Source = menuViewModel.MenuGroups;
            ((ListViewBase)semanticZoom.ZoomedOutView).ItemsSource = GroupedMenuItems.View.CollectionGroups;
        }

        private async void MenuGridViewSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void OrderListViewSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RemoveButton.Visibility = ((ListView)sender).SelectedItem != null ? Visibility.Visible : Visibility.Collapsed;
        }

        /// <summary>
        /// Populates the page with content passed during navigation.  Any saved state is also
        /// provided when recreating a page from a prior session.
        /// </summary>
        /// <param name="navigationParameter">The parameter value passed to
        /// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested.
        /// </param>
        /// <param name="pageState">A dictionary of state preserved by this page during an earlier
        /// session.  This will be null the first time a page is visited.</param>
        protected override void LoadState(Object navigationParameter, Dictionary<String, Object> pageState)
        {
        }

        /// <summary>
        /// Preserves state associated with this page in case the application is suspended or the
        /// page is discarded from the navigation cache.  Values must conform to the serialization
        /// requirements of <see cref="SuspensionManager.SessionState"/>.
        /// </summary>
        /// <param name="pageState">An empty dictionary to be populated with serializable state.</param>
        protected override void SaveState(Dictionary<String, Object> pageState)
        {
        }

       private async void CheckoutClick(object sender, RoutedEventArgs e)
        {
            IUICommand dialogResult;
            var messageDialog = new MessageDialog("End of Demo! Thank you for your interest! This application will go back to start.",
                                "The End");

            messageDialog.Commands.Add(new UICommand("Cancel"));
            messageDialog.Commands.Add(new UICommand("Ok"));

            messageDialog.DefaultCommandIndex = 1;

            dialogResult = await messageDialog.ShowAsync();
            string returnValue = dialogResult.Label;

            if (returnValue == "Ok")
            {
                MessageService.Clear();
                while (Frame.CanGoBack)
                {
                    GoBack(this, new RoutedEventArgs());
                }
            }
        }

        private void RemoveItemClick(object sender, RoutedEventArgs e)
        {
            ((Button)sender).CommandParameter = OrderListView.SelectedItem;
            OrderListView.SelectedIndex = -1;
        }
    }
}
