using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using OltivaHotel.PCL.Design;
using OltivaHotel.PCL.Model;
using OltivaHotel.PCL.ViewModel;
using OltivaHotel.Store.Services;

namespace OltivaHotel.Store.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            if (!SimpleIoc.Default.IsRegistered<IDownloader>())
                SimpleIoc.Default.Register<IDownloader, Downloader>();

            if (!SimpleIoc.Default.IsRegistered<INotificationService>())
                SimpleIoc.Default.Register<INotificationService, NotificationService>();

            if (ViewModelBase.IsInDesignModeStatic)
            {
                SimpleIoc.Default.Register<IDataService, DesignDataService>();
            }
            else
            {
                SimpleIoc.Default.Register<IDataService, DataService>();
            }

            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<MenuViewModel>();
            SimpleIoc.Default.Register<OrderViewModel>();
        }


       public MainViewModel Main
        {
            get { return ServiceLocator.Current.GetInstance<MainViewModel>(); }
        }

        public MenuViewModel MenuViewModel
        {
            get { return ServiceLocator.Current.GetInstance<MenuViewModel>(); }
        }

        public OrderViewModel OrderViewModel
        {
            get { return ServiceLocator.Current.GetInstance<OrderViewModel>(); }
        }

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}