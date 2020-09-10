using System.Threading.Tasks;
using weatherer.Models;

namespace weatherer.Interfaces
{
    public interface IForecastRetrievable
    {
        public Task<Weather> GetCurrentAsync();
    }
}