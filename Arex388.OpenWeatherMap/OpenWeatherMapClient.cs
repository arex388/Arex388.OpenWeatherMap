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
			new HistoricalWeatherResponseJsonConverter(),
			new LegacyCurrentWeatherResponseJsonConverter(),
			new LegacyWeatherJsonConverter(),
			new WeatherJsonConverter(),
			new WeatherConditionJsonConverter()
		},
		PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower
	};

	private readonly IValidator<HistoricalWeather.Request> _historicalWeatherValidator = services.GetRequiredService<IValidator<HistoricalWeather.Request>>();
	private readonly IValidator<LegacyCurrentWeather.Request> _legacyCurrentWeatherValidator = services.GetRequiredService<IValidator<LegacyCurrentWeather.Request>>();
	//private readonly IValidator<HistoricalWeather.Request> _historicalWeatherValidator = services.GetRequiredService<IValidator<HistoricalWeather.Request>>();
	private readonly HttpClient _httpClient = httpClient ?? services.GetRequiredService<IHttpClientFactory>().CreateClient(nameof(IOpenWeatherMapClient));
	private readonly OpenWeatherMapClientOptions _options = options ?? services.GetRequiredService<OpenWeatherMapClientOptions>();

	public Guid Id { get; } = Guid.NewGuid();

	public Task<HistoricalWeather.Response> HistoricalWeatherAsync(
		decimal latitude,
		decimal longitude,
		DateTimeOffset timestampAt,
		CancellationToken cancellationToken = default) => HistoricalWeatherAsync(new HistoricalWeather.Request {
			Latitude = latitude,
			Longitude = longitude,
			TimestampAt = timestampAt,
			Units = _options.Units
		}, cancellationToken);

	public async Task<HistoricalWeather.Response> HistoricalWeatherAsync(
		HistoricalWeather.Request request,
		CancellationToken cancellationToken = default) {
		if (cancellationToken.IsSupportedAndCancelled()) {
			return HistoricalWeather.Response.Cancelled;
		}

		// ReSharper disable once MethodHasAsyncOverloadWithCancellation
		var validationResult = _historicalWeatherValidator.Validate(request);

		if (!validationResult.IsValid) {
			return HistoricalWeather.Response.Invalid(validationResult);
		}

		try {
			var response = await _httpClient.GetAsync(request.GetEndpoint(_options), cancellationToken).ConfigureAwait(false);
			var historicalWeather = await response.Content.ReadFromJsonAsync<HistoricalWeather.Response>(_jsonSerializerOptions, cancellationToken).ConfigureAwait(false);

			historicalWeather!.Errors = historicalWeather.Error.HasValue()
				? [historicalWeather.Error!]
				: historicalWeather.Errors;

			return historicalWeather;
		} catch {
			return HistoricalWeather.Response.Failed;
		}
	}

	public Task<LegacyCurrentWeather.Response> LegacyCurrentWeatherAsync(
		decimal latitude,
		decimal longitude,
		CancellationToken cancellationToken = default) => LegacyCurrentWeatherAsync(new LegacyCurrentWeather.Request {
			Latitude = latitude,
			Longitude = longitude,
			Units = _options.Units
		}, cancellationToken);

	public async Task<LegacyCurrentWeather.Response> LegacyCurrentWeatherAsync(
		LegacyCurrentWeather.Request request,
		CancellationToken cancellationToken = default) {
		if (cancellationToken.IsSupportedAndCancelled()) {
			return LegacyCurrentWeather.Response.Cancelled;
		}

		// ReSharper disable once MethodHasAsyncOverloadWithCancellation
		var validationResult = _legacyCurrentWeatherValidator.Validate(request);

		if (!validationResult.IsValid) {
			return LegacyCurrentWeather.Response.Invalid(validationResult);
		}

		try {
			var response = await _httpClient.GetAsync(request.GetEndpoint(_options), cancellationToken).ConfigureAwait(false);
			var currentWeather = await response.Content.ReadFromJsonAsync<LegacyCurrentWeather.Response>(_jsonSerializerOptions, cancellationToken).ConfigureAwait(false);

			currentWeather!.Errors = currentWeather.Error.HasValue()
				? [currentWeather.Error!]
				: currentWeather.Errors;

			return currentWeather;
		} catch {
			return LegacyCurrentWeather.Response.Failed;
		}
	}

	//public Task<HistoricalWeather.Response> HistoricalWeatherAsync(
	//	decimal latitude,
	//	decimal longitude,
	//	DateTimeOffset startAt,
	//	DateTimeOffset endAt,
	//	CancellationToken cancellationToken = default) => HistoricalWeatherAsync(new HistoricalWeather.Request {
	//		EndAt = endAt,
	//		Latitude = latitude,
	//		Longitude = longitude,
	//		StartAt = startAt,
	//		Units = _options.Units
	//	}, cancellationToken);

	//public async Task<HistoricalWeather.Response> HistoricalWeatherAsync(
	//	HistoricalWeather.Request request,
	//	CancellationToken cancellationToken = default) {
	//	if (cancellationToken.IsSupportedAndCancelled()) {
	//		return HistoricalWeather.Response.Cancelled;
	//	}

	//	// ReSharper disable once MethodHasAsyncOverloadWithCancellation
	//	var validationResult = _historicalWeatherValidator.Validate(request);

	//	if (!validationResult.IsValid) {
	//		return HistoricalWeather.Response.Invalid(validationResult);
	//	}

	//	try {
	//		var response = await _httpClient.GetAsync(request.GetEndpoint(_options), cancellationToken).ConfigureAwait(false);
	//		var historicalWeather = await response.Content.ReadFromJsonAsync<HistoricalWeather.Response>(_jsonSerializerOptions, cancellationToken).ConfigureAwait(false);

	//		historicalWeather!.Errors = historicalWeather.Error.HasValue()
	//			? [historicalWeather.Error!]
	//			: historicalWeather.Errors;

	//		return historicalWeather;
	//	} catch {
	//		return HistoricalWeather.Response.Failed;
	//	}
	//}
}