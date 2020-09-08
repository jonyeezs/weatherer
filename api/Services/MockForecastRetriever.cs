using System;
using System.Threading.Tasks;
using weatherer.Interfaces;
using weatherer.Models;

namespace weatherer.Services
{
    public class MockForecastRetriever : IForecastRetrievable
    {
        public Task<Forecast> GetCurrentAsync()
        {
            return Task.FromResult(new Forecast(DateTime.UtcNow, 23));
        }
    }
}