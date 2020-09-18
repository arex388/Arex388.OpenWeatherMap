using Newtonsoft.Json;

#pragma warning disable 1591

namespace Arex388.OpenWeatherMap {
    public sealed class CurrentCondition {
        /// <summary>
        /// The current humidity.
        /// </summary>
        public string Humidity => $"{HumidityPercent}%";

        /// <summary>
        /// The current humidity percent.
        /// </summary>
        public byte HumidityPercent { get; set; }

        /// <summary>
        /// The current atmospheric pressure in hPa.
        /// </summary>
        public int Pressure { get; set; }

        /// <summary>
        /// The current ground-level atmospheric pressure in hPa.
        /// </summary>
        [JsonProperty("grnd_level")]
        public int PressureAtGroundLevel { get; set; }

        /// <summary>
        /// The current sea-level atmospheric presure in hPa.
        /// </summary>
        [JsonProperty("sea_level")]
        public int PressureAtSeaLevel { get; set; }

        /// <summary>
        /// The current temperature, varies by requested unit:
        ///
        /// - Default: kelvin
        /// - Metric: celsius
        /// - Imperial: fahrenheit
        /// </summary>
        [JsonProperty("temp")]
        public decimal Temperature { get; set; }

        /// <summary>
        /// The current temperature's feels like perception, varies by requested unit:
        ///
        /// - Default: kelvin
        /// - Metric: celsius
        /// - Imperial: fahrenheit
        /// </summary>
        [JsonProperty("feels_like")]
        public decimal TemperatureFeelsLike { get; set; }

        /// <summary>
        /// The current maximum observed temperature, varies by requested unit:
        ///
        /// - Default: kelvin
        /// - Metric: celsius
        /// - Imperial: fahrenheit
        /// </summary>
        [JsonProperty("temp_max")]
        public decimal TemperatureMaximum { get; set; }

        /// <summary>
        /// The current minimum observed temperature, varies by requested unit:
        ///
        /// - Default: kelvin
        /// - Metric: celsius
        /// - Imperial: fahrenheit
        /// </summary>
        [JsonProperty("temp_min")]
        public decimal TemperatureMinimum { get; set; }
    }
}