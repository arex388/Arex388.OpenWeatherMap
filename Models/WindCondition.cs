using Newtonsoft.Json;

#pragma warning disable 1591

namespace Arex388.OpenWeatherMap {
    public sealed class WindCondition {
        /// <summary>
        /// The wind's direction in degrees.
        /// </summary>
        [JsonProperty("deg")]
        public short Direction { get; set; }

        /// <summary>
        /// The wind's speed, varies by requested unit:
        /// 
        /// - Default: meter/second
        /// - Metric: meter/second
        /// - Imperial: miles/hour
        /// </summary>
        public decimal Speed { get; set; }

        /// <summary>
        /// The wind's gust speed, varies by requested unit:
        /// 
        /// - Default: meter/second
        /// - Metric: meter/second
        /// - Imperial: miles/hour
        /// </summary>
        [JsonProperty("gust")]
        public decimal? SpeedGust { get; set; }
    }
}