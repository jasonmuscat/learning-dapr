using System.Collections.Generic;
using System.Threading.Tasks;

using WeatherForecast.DTO;

namespace WeatherForecast.FrontEnd.Proxy
{
    public interface IWeatherForecastClient
    {
        Task<IEnumerable<WeatherForecast.DTO.WeatherForecast>> GetWeatherForecast(int count);
    }
}
