#pragma warning disable 1591

namespace Arex388.OpenWeatherMap {
    public abstract class ResponseBase {
        /// <summary>
        /// The response's error, if any.
        /// </summary>
        public string Error { get; set; }

        /// <summary>
        /// The response's raw JSON payload if debugging.
        /// </summary>
        public string Json { get; set; }

        /// <summary>
        /// The response's status.
        /// </summary>
        public abstract bool Success { get; }

        internal static T Invalid<T>(
            string error = null)
            where T : ResponseBase, new() => new T {
                Error = error ?? "The request is invalid."
            };
    }
}