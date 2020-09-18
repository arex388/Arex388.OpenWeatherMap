using Newtonsoft.Json;

#pragma warning disable 1591

namespace Arex388.OpenWeatherMap {
    public sealed class CloudCondition {
        /// <summary>
        /// The cloud's coverage.
        /// </summary>
        public string Coverage => $"{CoveragePercent}%";

        /// <summary>
        /// The cloud's coverate percent.
        /// </summary>
        [JsonProperty("all")]
        public byte CoveragePercent { get; set; }
    }
}