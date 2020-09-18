using Newtonsoft.Json;

#pragma warning disable 1591

namespace Arex388.OpenWeatherMap {
    public sealed class MeasuringLocation {
        /// <summary>
        /// The measuring location's latitude.
        /// </summary>
        [JsonProperty("lat")]
        public decimal Latitude { get; set; }

        /// <summary>
        /// The measuring location's longitude.
        /// </summary>
        [JsonProperty("lon")]
        public decimal Longitude { get; set; }
    }
}