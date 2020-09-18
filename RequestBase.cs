#pragma warning disable 1591

namespace Arex388.OpenWeatherMap {
    public abstract class RequestBase {
        internal abstract string Endpoint { get; }

        /// <summary>
        /// The request's unit formatting.
        /// </summary>
        public string Unit { get; set; }
    }
}