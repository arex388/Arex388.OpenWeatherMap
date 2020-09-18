using System.Collections.Generic;

#pragma warning disable 1591

namespace Arex388.OpenWeatherMap {
    public sealed class CurrentWeatherRequest :
        RequestBase {
        internal override string Endpoint {
            get {
                var parameters = new HashSet<string> {
                    $"units={Unit}"
                };

                if (Latitude.HasValue
                    && Longitude.HasValue) {
                    parameters.Add($"lat={Latitude}");
                    parameters.Add($"lon={Longitude}");
                }

                var query = string.Join("&", parameters);

                return $"weather?{query}";
            }
        }

        /// <summary>
        /// The location's latitude to query.
        /// </summary>
        public decimal? Latitude { get; set; }

        /// <summary>
        /// The location's longitude to query.
        /// </summary>
        public decimal? Longitude { get; set; }
    }
}