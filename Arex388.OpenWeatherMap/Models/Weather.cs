using System.Text.Json.Serialization;

namespace Arex388.OpenWeatherMap;

/// <summary>
/// The weather.
/// </summary>
public sealed class Weather {
	/// <summary>
	/// The conditions.
	/// </summary>
	[JsonPropertyName("data")]
	public IList<WeatherCondition> Conditions { get; init; } = [];

	/// <summary>
	/// The timezone's UTC offset.
	/// </summary>
	public TimeSpan UtcOffset { get; init; } = TimeSpan.Zero;
}