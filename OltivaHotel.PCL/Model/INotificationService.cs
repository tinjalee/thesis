using System.Threading.Tasks;

namespace OltivaHotel.PCL.Model
{
    public interface INotificationService
    {
        void Notify(string message);

        Task<bool> NotifyOkCancel(string message, string caption = "");
    }
}