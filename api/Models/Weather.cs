using System;

namespace weatherer.Models
{
    public class Weather
    {
        public DateTimeOffset DateUTC { get; private set; }
        public int TemperatureC
        { get; private set; }

        public string Climate { get; private set; }
        public string IconUrl { get; private set; }
        public int HumidityPercentage { get; private set; }
        public int Visibility { get; private set; }
        public int UVIndex { get; private set; }

        public Weather(DateTimeOffset date, int temperature,
            string climate, string iconUrl,
            int humidityPercentage, int visibility, int UVIndex)
        {
            this.DateUTC = date;
            this.TemperatureC = temperature;
            this.Climate = climate;
            this.IconUrl = iconUrl;
            this.HumidityPercentage = humidityPercentage;
            this.Visibility = visibility;
            this.UVIndex = UVIndex;
        }
    }
}