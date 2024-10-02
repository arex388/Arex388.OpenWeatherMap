using Arex388.OpenWeatherMap.Converters;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http.Json;
using System.Text.Json;

namespace Arex388.OpenWeatherMap;

internal sealed class OpenWeatherMapClient(
	IServiceProvider services,
	HttpClient? httpClient = null,
	OpenWeatherMapClientOptions? options = null) :
	IOpenWeatherMapClient {
	private static readonly JsonSerializerOptions _jsonSerializerOptions = new() {
		Converters = {
			new CurrentWeatherResponseJsonConverter(),
			new WeatherJsonConverter()
		},
		PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower
	};

	private readonly IValidator<CurrentWeather.Request> _currentWeatherValidator = services.GetRequiredService<IValidator<CurrentWeather.Request>>();
	private readonly HttpClient _httpClient = httpClient ?? services.GetRequiredService<IHttpClientFactory>().CreateClient(nameof(IOpenWeatherMapClient));
	private readonly OpenWeatherMapClientOptions _options = options ?? services.GetRequiredService<OpenWeatherMapClientOptions>();

	public Guid Id { get; } = Guid.NewGuid();

	public Task<CurrentWeather.Response> CurrentWeatherAsync(
		decimal latitude,
		decimal longitude,
		Units units,
		CancellationToken cancellationToken = default) => CurrentWeatherAsync(new CurrentWeather.Request {
			Latitude = latitude,
			Longitude = longitude,
			Units = units
		}, cancellationToken);

	public async Task<CurrentWeather.Response> CurrentWeatherAsync(
		CurrentWeather.Request request,
		CancellationToken cancellationToken = default) {
		if (cancellationToken.IsSupportedAndCancelled()) {
			return CurrentWeather.Response.Cancelled;
		}

		// ReSharper disable once MethodHasAsyncOverloadWithCancellation
		var validationResult = _currentWeatherValidator.Validate(request);

		if (!validationResult.IsValid) {
			return CurrentWeather.Response.Invalid(validationResult);
		}

		try {
			var response = await _httpClient.GetAsync(request.GetEndpoint(_options), cancellationToken).ConfigureAwait(false);
			var currentWeather = await response.Content.ReadFromJsonAsync<CurrentWeather.Response>(_jsonSerializerOptions, cancellationToken).ConfigureAwait(false);

			currentWeather!.Errors = currentWeather.Error.HasValue()
				? [currentWeather.Error!]
				: currentWeather.Errors;

			return currentWeather;
		} catch {
			return CurrentWeather.Response.Failed;
		}
	}
}