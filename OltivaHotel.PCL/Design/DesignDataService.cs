using System.Collections.ObjectModel;
using System.Threading.Tasks;
using OltivaHotel.PCL.Model;

namespace OltivaHotel.PCL.Design
{
    public class DesignDataService : IDataService
    {
        private IDownloader _downloader;

        public DesignDataService(IDownloader downloader)
        {
            _downloader = downloader;
        }

        public async Task<Menu> GetData()
        {
            var menu = new Menu {MenuItems = new ObservableCollection<MenuItem>()};

            for (int i = 0; i < 15; i++)
            {
                menu.MenuItems.Add(new MenuItem
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

            return menu;
        }
    }
}