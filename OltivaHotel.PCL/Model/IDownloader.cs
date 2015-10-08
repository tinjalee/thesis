using System.Xml.Linq;

namespace OltivaHotel.PCL.Model
{
    public interface IDownloader
    {
        XDocument DownloadString(string source);
    }
}