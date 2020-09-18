using Newtonsoft.Json;

#pragma warning disable 1591

namespace Arex388.OpenWeatherMap {
    public sealed class WeatherCondition {
        /// <summary>
        /// The conditions description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Icon name.
        /// </summary>
        public string Icon { get; set; }

        /// <summary>
        /// Icon id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The condition's name.
        /// </summary>
        [JsonProperty("main")]
        public string Name { get; set; }
    }
}