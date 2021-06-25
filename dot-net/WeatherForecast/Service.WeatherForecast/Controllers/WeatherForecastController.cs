using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using WeatherForecast.DTO;

namespace WeatherForecast.Service.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast.DTO.WeatherForecast> Get()
        {
            var rng = new Random();
            long tempC = rng.Next(-20, 55);

            return Enumerable.Range(1, 5).Select(index => new WeatherForecast.DTO.WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = tempC,
                TemperatureF = 32 + (int)(tempC / 0.5556),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
