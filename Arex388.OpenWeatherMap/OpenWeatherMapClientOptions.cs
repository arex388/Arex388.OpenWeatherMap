namespace Arex388.OpenWeatherMap;

/// <summary>
/// Open Weather Map API configuration options.
/// </summary>
public sealed class OpenWeatherMapClientOptions {
	/// <summary>
	/// The API key.
	/// </summary>
	public required string Key { get; init; }
}