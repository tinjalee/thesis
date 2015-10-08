using System.Threading.Tasks;

namespace OltivaHotel.PCL.Model
{
    public interface IDataService
    {
        Task<Menu> GetData();
    }
}