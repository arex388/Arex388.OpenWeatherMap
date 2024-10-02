namespace Arex388.OpenWeatherMap;

/// <summary>
/// Open Weather Map client.
/// </summary>
public interface IOpenWeatherMapClient {
	/// <summary>
	/// Get the current weather for a location.
	/// </summary>
	/// <param name="latitude">The location's latitude.</param>
	/// <param name="longitude">the location's longitude.</param>
	/// <param name="units">The response's units of measurement.</param>
	/// <param name="cancellationToken">The cancellation token.</param>
	/// <returns>The <see cref="CurrentWeather.Response"/> response.</returns>
	public Task<CurrentWeather.Response> CurrentWeatherAsync(
		decimal latitude,
		decimal longitude,
		Units units,
		CancellationToken cancellationToken = default);

	/// <summary>
	/// Get the current weather for a location.
	/// </summary>
	/// <param name="request">The <see cref="CurrentWeather.Request"/> request.</param>
	/// <param name="cancellationToken">The cancellation token.</param>
	/// <returns>The <see cref="CurrentWeather.Response"/> response.</returns>
	public Task<CurrentWeather.Response> CurrentWeatherAsync(
		CurrentWeather.Request request,
		CancellationToken cancellationToken = default);
}