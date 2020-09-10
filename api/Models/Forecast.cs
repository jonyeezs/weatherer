using System;

namespace weatherer.Models
{
    public class Forecast
    {
        public DateTimeOffset DateUTC { get; private set; }
        public int TemperatureC
        { get; private set; }

        public string Climate { get; private set; }
        public string iconUrl { get; private set; }
        public int HumidityPercentage { get; private set; }
        public int Visibility { get; private set; }
        public int UVIndex { get; private set; }

        public Forecast(DateTimeOffset date, int temperature, string climate, 
            int humidityPercentage, int visibility, int UVIndex)
        {
            this.DateUTC = date;
            this.TemperatureC = temperature;
            this.Climate = climate;
            this.HumidityPercentage = humidityPercentage;
            this.Visibility = visibility;
            this.UVIndex = UVIndex;
        }
    }
}