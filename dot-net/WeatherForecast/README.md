# Dapr .NET Weather service invocation example

## Prerequisites

- [.NET Core 3.1 or .NET 5+](https://dotnet.microsoft.com/download) installed
- [Dapr CLI](https://docs.dapr.io/getting-started/install-dapr-cli/)
- [Initialized Dapr environment](https://docs.dapr.io/getting-started/install-dapr-selfhost/)
- [Dapr .NET SDK](https://docs.dapr.io/developing-applications/sdks/dotnet/)


## Running the Service

Make sure to first run the [Weather Forecast Service](./WeatherForecastService) to have a service to invoke using:

```sh
dapr run --app-id weatherforecastservice --app-port 5000 --dapr-http-port 3500 --app-ssl dotnet run -- --urls=https://localhost:5000/ -p WeatherForecastService/WeatherForecastService.csproj
```

### Testing the Service

- [Accessing the API](https://localhost:5000/swagger/index.html)
- [Accessing the Service](https://localhost:5000/WeatherForecast/)
- [Accessing via the Dapr Sidecar](http://localhost:3500/v1.0/invoke/weatherforecastservice/method/weatherforecast)


## Running the Clients

>Make sure to first run the [Weather Forecast Service](./WeatherForecastService) before attempting to run any of the below clients.

Run the below command in the WeatherForecastFrontEnd directory:

```sh
dapr run --app-id weatherforecastclient -- dotnet run <sample number>
```

Running the following command will output a list of the samples included:

```sh
dapr run --app-id weatherforecastclient -- dotnet run
```

Press Ctrl+C to exit, and then run the command again and provide a sample number to run the samples.

For example run this command to run the 0th sample from the list produced earlier.

```sh
dapr run --app-id weatherforecastclient -- dotnet run 0
```

### HTTP client

See [InvokeServiceHttpExample.cs](./WeatherForecastFrontEnd/InvokeServiceHttpExample.cs) for an example of using `HttpClient` to invoke a service through Dapr.

### Dapr HTTP client

See [InvokeServiceDaprHttpExample.cs](./WeatherForecastFrontEnd/InvokeServiceDaprHttpExample.cs) for an example of using `DaprHttpClient` to invoke another service through Dapr.

### Dapr gRPC client

See [InvokeServiceDaprHttpExample.cs](./WeatherForecastFrontEnd/InvokeServiceDaprHttpExample.cs) for an example of using `DaprgRPCClient` to invoke another service through Dapr.

### FrontEnd Proxy client

Make sure to first run the [Weather Forecast Service](./WeatherForecastService) to have a service to invoke using:

```sh
dapr run --app-id frontendproxy --app-port 5001 --dapr-http-port 3501 --app-ssl dotnet run -- --urls=https://localhost:5001/ -p WeatherForecastFrontEndProxyService/WeatherForecastFrontEndProxyService.csproj
```

See [InvokeServiceDaprHttpExample.cs](./WeatherForecastFrontEnd/InvokeServiceDaprHttpExample.cs) for an example of using `DaprgRPCClient` to invoke another service through Dapr.