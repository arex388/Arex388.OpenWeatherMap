namespace Arex388.OpenWeatherMap;

/// <summary>
/// Open Weather Map client.
/// </summary>
public interface IOpenWeatherMapClient {
	/// <summary>
	/// Get the historical weather for a location. REQUIRES "One Call by Call" subscription.
	/// </summary>
	/// <param name="latitude">The location's latitude.</param>
	/// <param name="longitude">The location's longitude.</param>
	/// <param name="timestampAt">The timestamp to check.</param>
	/// <param name="cancellationToken">The cancellation token.</param>
	/// <returns>The <see cref="HistoricalWeather.Response"/> response.</returns>
	public Task<HistoricalWeather.Response> HistoricalWeatherAsync(
		decimal latitude,
		decimal longitude,
		DateTimeOffset timestampAt,
		CancellationToken cancellationToken = default);

	/// <summary>
	/// Get the historical weather for a location. REQUIRES "One Call by Call" subscription.
	/// </summary>
	/// <param name="request">The <see cref="HistoricalWeather.Request"/> request.</param>
	/// <param name="cancellationToken">The cancellation token.</param>
	/// <returns>The <see cref="HistoricalWeather.Response"/> response.</returns>
	public Task<HistoricalWeather.Response> HistoricalWeatherAsync(
		HistoricalWeather.Request request,
		CancellationToken cancellationToken = default);

	/// <summary>
	/// Get the current weather for a location.
	/// </summary>
	/// <param name="latitude">The location's latitude.</param>
	/// <param name="longitude">the location's longitude.</param>
	/// <param name="cancellationToken">The cancellation token.</param>
	/// <returns>The <see cref="LegacyCurrentWeather.Response"/> response.</returns>
	public Task<LegacyCurrentWeather.Response> LegacyCurrentWeatherAsync(
		decimal latitude,
		decimal longitude,
		CancellationToken cancellationToken = default);

	/// <summary>
	/// Get the current weather for a location.
	/// </summary>
	/// <param name="request">The <see cref="LegacyCurrentWeather.Request"/> request.</param>
	/// <param name="cancellationToken">The cancellation token.</param>
	/// <returns>The <see cref="LegacyCurrentWeather.Response"/> response.</returns>
	public Task<LegacyCurrentWeather.Response> LegacyCurrentWeatherAsync(
		LegacyCurrentWeather.Request request,
		CancellationToken cancellationToken = default);

	///// <summary>
	///// Get the historical weather for a location.
	///// </summary>
	///// <param name="latitude">The location's latitude.</param>
	///// <param name="longitude">The location's longitude.</param>
	///// <param name="startAt">The timestamp to start at.</param>
	///// <param name="endAt">The timestamp to stop at.</param>
	///// <param name="cancellationToken">The cancellation token.</param>
	///// <returns>The <see cref="HistoricalWeather.Response"/> response.</returns>
	//public Task<HistoricalWeather.Response> HistoricalWeatherAsync(
	//	decimal latitude,
	//	decimal longitude,
	//	DateTimeOffset startAt,
	//	DateTimeOffset endAt,
	//	CancellationToken cancellationToken = default);

	///// <summary>
	///// Get the historical weather for a location.
	///// </summary>
	///// <param name="request">The <see cref="HistoricalWeather.Request"/> request.</param>
	///// <param name="cancellationToken">The cancellation token.</param>
	///// <returns>The <see cref="HistoricalWeather.Response"/> response.</returns>
	//public Task<HistoricalWeather.Response> HistoricalWeatherAsync(
	//	HistoricalWeather.Request request,
	//	CancellationToken cancellationToken = default);
}