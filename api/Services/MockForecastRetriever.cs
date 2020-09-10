using System;
using System.Threading.Tasks;
using weatherer.Interfaces;
using weatherer.Models;

namespace weatherer.Services
{
    public class MockForecastRetriever : IForecastRetrievable
    {
        public Task<Weather> GetCurrentAsync()
        {
            return Task.FromResult(new Weather(DateTime.UtcNow, 23, "sunny", "https://via.placeholder.com/15", 68, 4, 0));
        }
    }
}