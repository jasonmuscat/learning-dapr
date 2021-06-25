namespace WeatherForecast.DTO
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;

    using System.Text.Json;
    using System.Text.Json.Serialization;

    public partial class WeatherForecast
    {
        [JsonPropertyName("date")]
        public DateTimeOffset Date { get; set; }

        [JsonPropertyName("temperatureC")]
        public long TemperatureC { get; set; }

        [JsonPropertyName("temperatureF")]
        public long TemperatureF { get; set; }

        [JsonPropertyName("summary")]
        public string Summary { get; set; }
    }
/*
    public partial class WeatherForecast
    {
        public static List<WeatherForecast> FromJson(string json) => JsonSerializer.Deserialize<List<WeatherForecast>>(json, Converter.Options);
    }

    public static class Serialize
    {
        public static string ToJson(this List<WeatherForecast> self) => JsonSerializer.Serialize(self, Converter.Options);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerOptions Options = new JsonSerializerOptions
        {
            //ReferenceHandler = ReferenceHandler.Preserve,
            WriteIndented = true

        };
    }
    */
}
