using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Tasks;

namespace OltivaHotel.WP
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        private void CallReceptionClick(object sender, RoutedEventArgs e)
        {
            MakePhoneCall(sender, "Oltiva Hotel Reception");
        }

        private void CallRoomServiceClick(object sender, RoutedEventArgs e)
        {
            MakePhoneCall(sender, "Oltiva Hotel Room Service");
        }

        private void EmailReceptionClick(object sender, RoutedEventArgs e)
        {
            ComposeEmail(sender);
        }

        private static void MakePhoneCall(object sender, string toWhom)
        {
            var callTask = new PhoneCallTask();
            callTask.PhoneNumber = ((HyperlinkButton) sender).Content as string;
            callTask.DisplayName = toWhom;
            callTask.Show();
        }

        private static void ComposeEmail(object sender)
        {
            var emailTask = new EmailComposeTask();
            emailTask.To = (string) ((HyperlinkButton) sender).Content;
            emailTask.Show();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            while (NavigationService.CanGoBack)
                NavigationService.RemoveBackEntry();

            base.OnNavigatedTo(e);
        }
    }
}