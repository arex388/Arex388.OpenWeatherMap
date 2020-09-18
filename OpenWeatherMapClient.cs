using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

#pragma warning disable 1591

namespace Arex388.OpenWeatherMap {
    public sealed class OpenWeatherMapClient {
        private readonly bool _debug;
        private readonly HttpClient _httpClient;
        private readonly string _key;

        /// <summary>
        /// OpenWeatherMap client.
        /// </summary>
        /// <param name="httpClient">The HttpClient instance to use.</param>
        /// <param name="key">The API key to use.</param>
        /// <param name="debug">Flag if the raw JSON payload should be added to the parsed response.</param>
        public OpenWeatherMapClient(
            HttpClient httpClient,
            string key,
            bool debug = false) {
            _debug = debug;
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _key = key ?? throw new ArgumentNullException(nameof(key));
        }

        /// <summary>
        /// Get the current weather for a location.
        /// </summary>
        /// <param name="latitude">The location's latitude.</param>
        /// <param name="longitude">The location's longitude.</param>
        /// <param name="unit">The unit type for the response.</param>
        /// <returns>CurrentWeatherResponse</returns>
        public Task<CurrentWeatherResponse> CurrentWeatherAsync(
            decimal latitude,
            decimal longitude,
            string unit) => CurrentWeatherAsync(new CurrentWeatherRequest {
                Latitude = latitude,
                Longitude = longitude,
                Unit = unit
            });

        /// <summary>
        /// Get the current weather for a location.
        /// </summary>
        /// <param name="request">The request container.</param>
        /// <returns>CurrentWeatherResponse</returns>
        public async Task<CurrentWeatherResponse> CurrentWeatherAsync(
            CurrentWeatherRequest request) {
            if (request is null) {
                return NullRequestResponse<CurrentWeatherResponse>();
            }

            var response = await GetResponseAsync(request).ConfigureAwait(false);
            var responseObj = JsonConvert.DeserializeObject<CurrentWeatherResponse>(response);

            if (_debug) {
                responseObj.Json = response;
            }

            return responseObj;
        }

        //  ========================================================================
        //  Response
        //  ========================================================================

        private async Task<string> GetResponseAsync(
            RequestBase request) {
            var endpoint = $"https://api.openweathermap.org/data/2.5/{request.Endpoint}&appid={_key}";

            try {
                return await GetGetResponseAsync(endpoint).ConfigureAwait(false);
            } catch (HttpRequestException e) {
                var error = $"{e.Message}\n{e.InnerException?.Message}".Trim();

                return $"{{\"error\":\"{error}\",\"success\":false}}";
            } catch (TaskCanceledException) {
                return "{{\"error\":\"The request has timed out\",\"success\":false}}";
            }
        }

        private async Task<string> GetGetResponseAsync(
            string endpoint) {
            var response = await _httpClient.GetAsync(endpoint).ConfigureAwait(false);

            return await response.Content.ReadAsStringAsync().ConfigureAwait(false);
        }

        //  ========================================================================
        //  Utilities
        //  ========================================================================

        private static T NullRequestResponse<T>()
            where T : ResponseBase, new() => ResponseBase.Invalid<T>();
    }
}