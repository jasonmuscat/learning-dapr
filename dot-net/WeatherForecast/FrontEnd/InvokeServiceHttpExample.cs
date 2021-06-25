using System;
using System.Collections.Generic;

using System.Net.Http;
using System.Net.Http.Json;

using System.Threading;
using System.Threading.Tasks;

using WeatherForecast.DTO;


namespace WeatherForecast.FrontEnd
{

    public class InvokeServiceHttpExample : InvokeExample
    {
        public override string DisplayName => "Invoking an HTTP service with Http Client";

        public override async Task RunAsync(CancellationToken cancellationToken)
        {


            using var client = new HttpClient();

            // Invokes a GET method named "weatherforecast"
            Console.WriteLine("Invoking weatherforecast");
            var weatherForecasts = await client.GetFromJsonAsync<List<WeatherForecast.DTO.WeatherForecast>> ("http://localhost:3500/v1.0/invoke/weatherforecastservice/method/weatherforecast");

            foreach (var weatherForecast in weatherForecasts)
            {
                Console.Write($"Date:{weatherForecast.Date}, TemperatureC:{weatherForecast.TemperatureC}, TemperatureF:{weatherForecast.TemperatureF}, Summary:{weatherForecast.Summary}");
            }
        }

    }

}
