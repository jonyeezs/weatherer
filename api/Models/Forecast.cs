using System;

namespace weatherer.Models
{
    public class Forecast
    {
        public DateTimeOffset DateUTC { get; private set; }
        public int TemperatureC { get; private set; }

        public Forecast(DateTimeOffset date, int temperature)
        {
            this.DateUTC = date;
            this.TemperatureC = temperature;
        }
    }
}