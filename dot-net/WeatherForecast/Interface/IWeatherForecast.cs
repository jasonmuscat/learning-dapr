using System;

namespace WeatherForecast.Interface
{
    public interface IWeatherForecast : IForecast   
    {
        
        public int TemperatureC { get; set; }

        public int TemperatureF { get; }

        public string Summary { get; set; }

    }
}
