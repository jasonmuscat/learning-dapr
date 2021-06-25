# Dapr .NET Weather service invocation example

>Credits to [Laurent Kempé](https://laurentkempe.com/) for the bulk of the work sournding this.  You can find some of Laurent's other Dapr resource below:
>- [Blog](https://laurentkempe.com/)
>- [GitHub](https://github.com/laurentkempe)
>- [Presentation](https://laurentkempe.com/presentations/Introduction%20to%20Dapr%20.NET%20SDK/Introduction%20to%20Dapr%20.NET%20SDK.pptx)
>- [YouTube](https://www.youtube.com/watch?v=XtASb2tmo5c&t=119s)
## Prerequisites

- [.NET 5.x](https://dotnet.microsoft.com/download) installed
- [Dapr CLI](https://docs.dapr.io/getting-started/install-dapr-cli/)
- [Initialized Dapr environment](https://docs.dapr.io/getting-started/install-dapr-selfhost/)
- [Dapr .NET SDK](https://docs.dapr.io/developing-applications/sdks/dotnet/)


## Running the Service

>All the following examples must be run from the [Weather Forecast Solution folder](./) which is the same folder as this README.

Make sure to first run the [Weather Forecast Service](./Service.WeatherForecast).  To start the service and the Dapr sidecar use:

```sh
dapr run --app-id weatherforecastservice --app-port 5000 --dapr-http-port 3500 --app-ssl dotnet run -- --urls=https://localhost:5000/ -p Service.WeatherForecast/Service.WeatherForecast.csproj
```

### Testing the Service

- [Accessing the API](https://localhost:5000/swagger/index.html)
- [Accessing the Service](https://localhost:5000/WeatherForecast/)
- [Accessing via the Dapr Sidecar](http://localhost:3500/v1.0/invoke/weatherforecastservice/method/weatherforecast)


## Running the Clients

>The [Weather Forecast Service](./Service.WeatherForecast) must be running to produce the intended results.

Any of the Weather Forecast Front End clients can be run using the convention:

```sh
dapr run --app-id weatherforecastclient -- dotnet run <sample number> -p FrontEnd/FrontEnd.csproj
```

To output a list of sample clients simply run:

```sh
dapr run --app-id weatherforecastclient -- dotnet run -p FrontEnd/FrontEnd.csproj
```

For example run this command to run the 0th sample from the list produced earlier.

```sh
dapr run --app-id weatherforecastclient -- dotnet run 0 -p FrontEnd/FrontEnd.csproj
```

To exit, simple press Ctrl+C to exit, and then run the above command again and re-choose the sample.

### HTTP client

See [InvokeServiceHttpExample.cs](./FrontEnd/InvokeServiceHttpExample.cs) for an example of using `HttpClient` to invoke a service through Dapr.

### Dapr HTTP client

See [InvokeServiceDaprHttpExample.cs](./FrontEnd/InvokeServiceDaprHttpExample.cs) for an example of using `DaprHttpClient` to invoke a service through Dapr.

## FrontEnd Proxy client

The FrontEnd Proxy client is an example of of Service-to-Service invocation.  In this sample, we illustrate how the  Weather Forecast Service is called via a Front End Proxy Service by the Front Ends rather than the client calling the Service directly.  To run this sample:

1. Run the [Weather Forecast Service](./Service.WeatherForecast)
2. Run the [Weather Forecast Front End Proxy Service](./FrontEnd.Proxy) using:

```sh
dapr run --app-id frontendproxy --app-port 5001 --dapr-http-port 3501 --app-ssl dotnet run -- --urls=https://localhost:5001/ -p FrontEnd.Proxy/FrontEnd.Proxy.csproj
```

3. Invoke the Proxy Service using a Dapr Http Client configured to call the Proxy Service using:

```sh
dapr run --app-id weatherforecastclient -- dotnet run 2 -p FrontEnd/FrontEnd.csproj
```

See [InvokeProxyServiceDaprHttpExample.cs](./FrontEnd/InvokeProxyServiceDaprHttpExample.cs) for an example of using `DaprHttpClient` to invoke a service that calls another service through Dapr.

### Testing the Proxy Service

- [Accessing the API](https://localhost:5001/swagger/index.html)
- [Accessing the Service](https://localhost:5001/WeatherForecast/)
- [Accessing via the Dapr Sidecar](http://localhost:3501/v1.0/invoke/frontendproxy/method/weatherforecast)


## IoC Considerations


> In a addition to Refit, take a look at:  [QuickType](https://quicktype.io) as it faciliates the simplified generation Data Transfer Objects from JSON.  Simply 


### Dapr gRPC client

See [InvokeServiceDaprHttpExample.cs](./FrontEnd/InvokeServiceDaprHttpExample.cs) for an example of using `DaprgRPCClient` to invoke a service through Dapr.