using System.Collections.Generic;
using System.Threading.Tasks;

using WeatherForecastService;

namespace WeatherForecastFrontEndProxyService
{
    public interface IWeatherForecastClient
    {
        Task<IEnumerable<WeatherForecast>> GetWeatherForecast(int count);
    }
}
