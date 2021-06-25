using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

using WeatherForecast.DTO;

namespace WeatherForecast.FrontEnd.Proxy
{
    public class WeatherForecastClient : IWeatherForecastClient
    {
        private readonly HttpClient _backendHttpClient;

        public WeatherForecastClient(HttpClient backendHttpClient)
        {
            _backendHttpClient = backendHttpClient;
        }

        public async Task<IEnumerable<WeatherForecast.DTO.WeatherForecast>> GetWeatherForecast(int count)
        {
            var weatherForecasts =
                await _backendHttpClient.GetFromJsonAsync<List<WeatherForecast.DTO.WeatherForecast>>("weatherforecastservice");

            return weatherForecasts?.Take(count);
        }
    }
}