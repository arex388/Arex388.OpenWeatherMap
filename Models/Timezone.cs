#pragma warning disable 1591

namespace Arex388.OpenWeatherMap {
    public sealed class Timezone {
        /// <summary>
        /// The location's offset in seconds from UTC.
        /// </summary>
        public int OffsetSeconds { get; set; }

        /// <summary>
        /// The location's offset from UTC.
        /// </summary>
        public string Offset { get; set; }
    }
}