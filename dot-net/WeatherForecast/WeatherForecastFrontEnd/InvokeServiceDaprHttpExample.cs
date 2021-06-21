using System;
using System.Collections.Generic;

using System.Net.Http;
using System.Net.Http.Json;

using System.Threading;
using System.Threading.Tasks;

using Dapr.Client;

using WeatherForecastService;


namespace WeatherForecastFrontEnd
{

    public class InvokeServiceDaprHttpExample : InvokeExample
    {
        public override string DisplayName => "Invoking an HTTP service with the Dapr Client via Http";

        public override async Task RunAsync(CancellationToken cancellationToken)
        {


            using var client = new DaprClientBuilder().Build();

            // Invokes a GET method named "weatherforecast"
            Console.WriteLine("Invoking weatherforecast");
            var weatherForecasts = await client.InvokeMethodAsync<List<WeatherForecast>>(HttpMethod.Get, "weatherforecastservice", "weatherforecast",cancellationToken);

            foreach (var weatherForecast in weatherForecasts)
            {
                Console.Write($"Date:{weatherForecast.Date}, TemperatureC:{weatherForecast.TemperatureC}, TemperatureF:{weatherForecast.TemperatureF}, Summary:{weatherForecast.Summary}");
            }
        }

    }

}
