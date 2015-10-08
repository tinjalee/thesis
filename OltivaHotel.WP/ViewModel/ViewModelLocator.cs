using System.Diagnostics.CodeAnalysis;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using OltivaHotel.PCL.Design;
using OltivaHotel.PCL.Model;
using OltivaHotel.PCL.ViewModel;
using OltivaHotel.WP.Services;

namespace OltivaHotel.WP.ViewModel
{
    public class ViewModelLocator
    {
        static ViewModelLocator()
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

        [SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public MainViewModel Main
        {
            get { return ServiceLocator.Current.GetInstance<MainViewModel>(); }
        }

        [SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public MenuViewModel MenuViewModel
        {
            get { return ServiceLocator.Current.GetInstance<MenuViewModel>(); }
        }

        [SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public OrderViewModel OrderViewModel
        {
            get { return ServiceLocator.Current.GetInstance<OrderViewModel>(); }
        }

        /// <summary>
        ///     Cleans up all the resources.
        /// </summary>
        public static void Cleanup()
        {
        }
    }
}