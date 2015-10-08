using System;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using OltivaHotel.PCL.Model;
using OltivaHotel.PCL.ViewModel;

namespace OltivaHotel.WP
{
    public partial class OrderPage : PhoneApplicationPage
    {
        public OrderPage()
        {
            InitializeComponent();
        }

        private void GoBack(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void CheckOut(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result =
                MessageBox.Show("End of Demo! Thank you for your interest! This application will go back to start.",
                                "The End", MessageBoxButton.OKCancel);

            if (result == MessageBoxResult.OK)
            {
                MessageService.Clear();
                NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
            }
        }

        private void RemoveItem(object sender, EventArgs e)
        {
            ((OrderViewModel) DataContext).RemoveFromOrder.Execute(OrderList.SelectedItem);
        }

        private void OrderListSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ApplicationBar.Mode = OrderList.SelectedItem != null || OrderList.SelectedIndex > -1
                                      ? ApplicationBarMode.Default
                                      : ApplicationBarMode.Minimized;
        }
    }
}