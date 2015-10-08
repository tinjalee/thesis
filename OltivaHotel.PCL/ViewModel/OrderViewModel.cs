using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using OltivaHotel.PCL.Model;

namespace OltivaHotel.PCL.ViewModel
{
    public class OrderViewModel : ViewModelBase
    {
        private readonly INotificationService _notificationService;
        private IDataService _dataService;

        private ObservableCollection<MenuItem> _orderList;

        public OrderViewModel(IDataService dataService, INotificationService notificationService)
        {
            _dataService = dataService;
            _notificationService = notificationService;
            _orderList = new ObservableCollection<MenuItem>();

            if (IsInDesignMode)
            {
                for (int i = 0; i < 15; i++)
                {
                    OrderList.Add(new MenuItem
                        {
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. " +
                                          "Sed nisl tortor, mattis a venenatis vel, vulputate non nisl. " +
                                          "Donec at ipsum eget nibh scelerisque ultricies at eu lorem.",
                            IsTodaysSpecial = i%3 == 0,
                            Name = "Lorem ipsum dolor sit amet " + i,
                            Price = 20 + i,
                            Type = i%3 == 0 ? "breakfast" : "dessert"
                        });
                }
            }
        }

        public ObservableCollection<MenuItem> OrderList
        {
            get { return _orderList; }
            set { _orderList = value; }
        }

        public ICommand RemoveFromOrder
        {
            get
            {
                return new RelayCommand<object>(async (item) =>
                    {
                        if (item != null)
                        {
                            if (await _notificationService.NotifyOkCancel("Do you want to remove this item?", "Remove"))
                            {
                                MessageService.StaticMenuItemList.Remove((MenuItem) item);
                                OrderList.Remove((MenuItem) item);
                            }
                        }
                    });
            }
        }


        public RelayCommand SendOrderCommand
        {
            get { return new RelayCommand(() => _notificationService.Notify("Order sent to room service, thank you.")); }
        }

        public ICommand PageLoaded
        {
            get { return new RelayCommand(LoadData); }
        }

        private void LoadData()
        {
            try
            {
                if (MessageService.StaticMenuItemList != null && MessageService.StaticMenuItemList.Count > 0)
                {
                    _orderList.Clear();

                    foreach (MenuItem menuItem in MessageService.StaticMenuItemList)
                    {
                        _orderList.Add(menuItem);
                    }
                }
            }
            catch (Exception e)
            {
                _notificationService.Notify(e.Message);
            }
        }
    }
}