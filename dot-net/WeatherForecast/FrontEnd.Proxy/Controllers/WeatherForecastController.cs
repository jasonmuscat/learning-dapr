using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using WeatherForecast.DTO;

namespace WeatherForecast.FrontEnd.Proxy.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastProxyController : ControllerBase
    {
        private readonly IWeatherForecastClient _weatherForecastClient;

        public WeatherForecastProxyController(IWeatherForecastClient weatherForecastClient)
        {
            _weatherForecastClient = weatherForecastClient;
        }

        [HttpGet]
        public async Task<IEnumerable<WeatherForecast.DTO.WeatherForecast>> Get(int count)
        {
            return await _weatherForecastClient.GetWeatherForecast(count);
        }
    }
}
