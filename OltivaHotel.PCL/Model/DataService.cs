using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OltivaHotel.PCL.Model
{
    public class DataService : IDataService
    {
        private readonly IDownloader _downloader;

        public DataService(IDownloader downloader)
        {
            _downloader = downloader;
        }

        public async Task<Menu> GetData()
        {
            XDocument xml = _downloader.DownloadString("");

            var menu = new Menu {MenuItems = new ObservableCollection<MenuItem>()};

            foreach (XElement element in xml.Root.Elements())
            {
                menu.MenuItems.Add(new MenuItem
                    {
                        Name = !string.IsNullOrEmpty(element.Element("name").Value) ? element.Element("name").Value : "",
                        Price = !string.IsNullOrEmpty(element.Element("price").Value)
                                    ? Convert.
                                          ToDouble(element.Element("price").Value)
                                    : 0,
                        Type = !string.IsNullOrEmpty(element.Element("type").Value) ? element.Element("type").Value : "",
                        Description =
                            !string.IsNullOrEmpty(element.Element("description").Value)
                                ? element.Element("description").Value
                                : "",
                        IsTodaysSpecial = !string.IsNullOrEmpty(element.Element("special").Value)
                    });
            }
            return menu;
        }
    }
}