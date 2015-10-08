using System.Xml.Linq;
using OltivaHotel.PCL.Model;

namespace OltivaHotel.WP.Services
{
    public class Downloader : IDownloader
    {
        public XDocument DownloadString(string source)
        {
            XDocument xml = XDocument.Load("Services/Menu.xml");
            return xml;
        }
    }
}