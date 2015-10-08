using System.Threading.Tasks;
using System.Windows;
using OltivaHotel.PCL.Model;

namespace OltivaHotel.WP.Services
{
    public class NotificationService : INotificationService
    {
        public void Notify(string message)
        {
            MessageBox.Show(message);
        }

        public async Task<bool> NotifyOkCancel(string message, string caption = "")
        {
            var result = MessageBox.Show(message, caption, MessageBoxButton.OKCancel);
            return result == MessageBoxResult.OK;
        }
    }
}