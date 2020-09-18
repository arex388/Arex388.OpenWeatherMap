using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;

#pragma warning disable 1591

namespace Arex388.OpenWeatherMap {
    public sealed class CurrentWeatherResponse :
        ResponseBase {
        [JsonProperty("id")]
        private int CityId { get; set; }

        [JsonProperty("name")]
        private string CityName { get; set; }

        /// <summary>
        /// The current cloud condition.
        /// </summary>
        public CloudCondition Clouds { get; set; }

        /// <summary>
        /// The current weather condition.
        /// </summary>
        [JsonProperty("main")]
        public CurrentCondition Current { get; set; }

        /// <summary>
        /// The last time the current condition was measured in UTC.
        /// </summary>
        [JsonProperty("dt"), JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime MeasuredAtUtc { get; set; }

        /// <summary>
        /// The location's city.
        /// </summary>
        public MeasuringCity MeasuringCity => GetMeasuringCity(this);

        /// <summary>
        /// The current location.
        /// </summary>
        [JsonProperty("coord")]
        public MeasuringLocation MeasuringLocation { get; set; }

        /// <summary>
        /// The response's status.
        /// </summary>
        public override bool Success => true;

        /// <summary>
        /// Miscellaneous details.
        /// </summary>
        [JsonProperty("sys")]
        public Miscellaneous Miscellaneous { get; set; }

        [JsonProperty("timezone")]
        private short TimezoneSeconds { get; set; }

        /// <summary>
        /// The location's timezone.
        /// </summary>
        public Timezone Timezone => GetTimezone(this);

        /// <summary>
        /// The current visibility in meters.
        /// </summary>
        public int Visibility { get; set; }

        /// <summary>
        /// The current weather conditions.
        /// </summary>
        [JsonProperty("weather")]
        public IList<WeatherCondition> Weather { get; } = new List<WeatherCondition>();

        /// <summary>
        /// The current wind condition.
        /// </summary>
        public WindCondition Wind { get; set; }

        //  ========================================================================
        //  Utilities
        //  ========================================================================

        private static readonly IDictionary<int, string> Signs = new Dictionary<int, string> {
            {-1, "-"},
            { 0, "+" },
            { 1, "+" }
        };

        private static MeasuringCity GetMeasuringCity(
            CurrentWeatherResponse response) => new MeasuringCity {
                Id = response.CityId,
                Name = response.CityName
            };

        private static Timezone GetTimezone(
            CurrentWeatherResponse response) {
            var offsetSign = Math.Sign(response.TimezoneSeconds);
            var offset = TimeSpan.FromSeconds(response.TimezoneSeconds).ToString("hh\\:mm", CultureInfo.InvariantCulture);
            var sign = Signs[offsetSign];

            return new Timezone {
                OffsetSeconds = response.TimezoneSeconds,
                Offset = $"{sign}{offset}"
            };
        }
    }
}