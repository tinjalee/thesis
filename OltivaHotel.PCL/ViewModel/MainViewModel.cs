using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using OltivaHotel.PCL.Model;

namespace OltivaHotel.PCL.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IDataService _dataService;
        private readonly INotificationService _notificationService;
        private Menu _menu;
        private RelayCommand<string> _menuClickCommand;

        public MainViewModel(IDataService dataService, INotificationService notificationService)
        {
            _dataService = dataService;
            _notificationService = notificationService;

            LoadData();
        }

        public string ApplicationName
        {
            get { return "Oltiva Hotel"; }
        }

        public Menu Menu
        {
            get { return _menu; }
        }

        public RelayCommand<string> MenuClickCommand
        {
            get { return _menuClickCommand ?? (_menuClickCommand = new RelayCommand<string>(PassMessageToMessageService)); }
        }

        public ICommand AddToOrder
        {
            get
            {
                return new RelayCommand<object>(async (item) =>
                    {
                        if (item != null)
                        {
                            if (await _notificationService.NotifyOkCancel("Do you want to add this item to order?",
                                                                    "Add to your order"))
                                MessageService.StaticMenuItemList.Add((MenuItem) item);
                        }
                    });
            }
        }

        private async void LoadData()
        {
            _menu = await _dataService.GetData();
            TodaysSpecial();
        }

        private void TodaysSpecial()
        {
            ObservableCollection<MenuItem> tempMenuItems = _menu.MenuItems;
            _menu.MenuItems = new ObservableCollection<MenuItem>(tempMenuItems.Where(item => item.IsTodaysSpecial));
        }

        private void PassMessageToMessageService(object parameter)
        {
            if (parameter is string)
                MessageService.PassMessage(parameter.ToString());
        }
    }
}