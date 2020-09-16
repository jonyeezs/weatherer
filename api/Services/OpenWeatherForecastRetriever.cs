using System;
using System.Linq;
using System.Threading.Tasks;
using weatherer.Interfaces;
using weatherer.Libraries.OpenWeather;

namespace weatherer.Services
{
    public class OpenWeatherForecastRetriever : IForecastRetrievable
    {
        private readonly IOpenWeatherClient _client;

        public OpenWeatherForecastRetriever(IOpenWeatherClient client)
        {
            this._client = client;
        }
        public async Task<Models.Weather> GetCurrentAsync()
        {
            var result = await this._client.OneCallAsync(new OneCallRequest
            {
                Latitude = -27.470125,
                Longitude = 153.021072
            });

            return new Models.Weather(DateTimeOffset.FromUnixTimeMilliseconds(result.Current.Dt), Convert.ToInt32(result.Current.Temp),
                result.Current.Weather.First().Main,
                $"http://openweathermap.org/img/wn/{result.Current.Weather.First().Icon}@2x.png",
                result.Current.Humidity, result.Current.Visibility, Convert.ToInt32(result.Current.Uvi));
        }
    }
}
