using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using OltivaHotel.PCL.Model;

namespace OltivaHotel.PCL.ViewModel
{
    public class MenuViewModel : ViewModelBase
    {
        private readonly IDataService _dataService;
        private readonly ObservableCollection<MenuGroup> _menuGroups;
        private readonly INotificationService _notificationService;

        private Menu _menu;
        private int _selectedIndex;

        public MenuViewModel(IDataService dataService, INotificationService notificationService)
        {
            _dataService = dataService;
            _notificationService = notificationService;
            LoadData();
            _menuGroups = new ObservableCollection<MenuGroup>();
        }

        public Menu Menu
        {
            get { return _menu; }
            set { _menu = value; }
        }

        public string ApplicationName
        {
            get { return "OLTIVA HOTEL"; }
        }

        public bool IsBusy { get; set; }

        public int SelectedIndex
        {
            get { return _selectedIndex; }
            set
            {
                if (value < 0)
                    _selectedIndex = value;
                else
                    _selectedIndex = -1;

                RaisePropertyChanged();
            }
        }

        public ObservableCollection<MenuGroup> MenuGroups
        {
            get
            {
                string condition = MessageService.MessageStack != null && MessageService.MessageStack.Count > 0
                                       ? MessageService.ReadMessage()
                                       : "All";
                GroupItems(condition);
                return _menuGroups;
            }
        }

        public bool CanProceedToCheckout { get; set; }

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

        private void GroupItems(string condition)
        {
            if (_menuGroups != null && _menuGroups.Count > 0)
                _menuGroups.Clear();

            if (_menu == null)
                LoadData();

            if (_menu != null)
            {
                IsBusy = true;

                var groupedItems = from menuItem in _menu.MenuItems
                                   group menuItem by menuItem.Type
                                   into g
                                   select new
                                       {
                                           GroupName = g.Key,
                                           MenuItems = g
                                       };

                if (condition == "All")
                {
                    foreach (var groupedItem in groupedItems)
                    {
                        var group = new MenuGroup();
                        group.GroupName = groupedItem.GroupName;
                        group.MenuItems = new ObservableCollection<MenuItem>(groupedItem.MenuItems);

                        _menuGroups.Add(group);
                    }
                }
                else
                {
                    foreach (var groupedItem in groupedItems)
                    {
                        if (groupedItem.GroupName.ToLower() == condition ||
                            groupedItem.GroupName.ToLower() == "beverages" ||
                            groupedItem.GroupName.ToLower() == "dessert" ||
                            groupedItem.GroupName.ToLower() == "red wine" ||
                            groupedItem.GroupName.ToLower() == "white wine" ||
                            groupedItem.GroupName.ToLower() == "dessert wine" ||
                            groupedItem.GroupName.ToLower() == "champagne wine" ||
                            groupedItem.GroupName.ToLower() == "spirits"
                            )
                        {
                            var group = new MenuGroup();
                            group.GroupName = groupedItem.GroupName;
                            group.MenuItems = new ObservableCollection<MenuItem>(groupedItem.MenuItems);

                            _menuGroups.Add(group);
                        }
                    }
                }

                IsBusy = false;
            }
        }

        private async void LoadData()
        {
            _menu = await _dataService.GetData();
        }
    }

    public class MenuGroup
    {
        public string GroupName { get; set; }
        public ObservableCollection<MenuItem> MenuItems { get; set; }
    }
}