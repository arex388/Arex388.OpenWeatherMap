namespace Arex388.OpenWeatherMap;

/// <summary>
/// Open Weather Map API client factory for interacting with multiple accounts.
/// </summary>
public interface IOpenWeatherMapClientFactory {
	/// <summary>
	/// Create and cache an instance of the Open Weather Map API client.
	/// </summary>
	/// <param name="options">The client's configuration options.</param>
	/// <returns>An instance of the client.</returns>
	IOpenWeatherMapClient CreateClient(
		OpenWeatherMapClientOptions options);
}