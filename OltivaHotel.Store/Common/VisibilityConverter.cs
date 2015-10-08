using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OltivaHotel.PCL.Model;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace OltivaHotel.Store.Common
{
    class VisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (parameter is MenuItem)
            {
                return value as MenuItem;
            }
            if (value != null && value is ObservableCollection<MenuItem>)
                return ((ObservableCollection<MenuItem>) value).Count > 0 ? Visibility.Visible : Visibility.Collapsed;
            
            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
