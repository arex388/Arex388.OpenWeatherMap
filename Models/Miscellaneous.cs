using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

#pragma warning disable 1591

namespace Arex388.OpenWeatherMap {
    public sealed class Miscellaneous {
        /// <summary>
        /// The location's country.
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// The location's sunrise in UTC.
        /// </summary>
        [JsonProperty("sunrise"), JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime SunriseAtUtc { get; set; }

        /// <summary>
        /// The location's sunset in UTC.
        /// </summary>
        [JsonProperty("sunset"), JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime SunsetAtUtc { get; set; }
    }
}