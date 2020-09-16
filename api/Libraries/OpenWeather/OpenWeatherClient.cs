using Microsoft.Extensions.Options;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace weatherer.Libraries.OpenWeather
{

    public class OneCallRequest
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Part => "minutely,hourly,daily";
    }

    public interface IOpenWeatherClient
    {
        Task<OneCallResponse> OneCallAsync(OneCallRequest request);
    }

    public class OpenWeatherClient : IOpenWeatherClient
    {
        private readonly HttpClient _httpClient;
        private string _token { get; set; }

        public OpenWeatherClient(HttpClient httpClient, IOptions<OpenWeatherSettings> settings)
        {
            this._httpClient = httpClient;

            this._httpClient.BaseAddress = new Uri(settings.Value.Url);
            this._token = settings.Value.Token;
        }

        public async Task<OneCallResponse> OneCallAsync(OneCallRequest request)
        {
            var resp = await this._httpClient.GetAsync($"onecall?lat={request.Latitude}&lon={request.Longitude}&exclude={request.Part}&appid={this._token}");

            return await resp.Content.ReadAsAsync<OneCallResponse>();
        }
    }
}
