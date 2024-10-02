using System.Text.Json.Serialization;

namespace Arex388.OpenWeatherMap;

/// <summary>
/// The wind conditions.
/// </summary>
public sealed class WindConditions {
	/// <summary>
	/// The wind's direction.
	/// </summary>
	[JsonPropertyName("deg")]
	public short Direction { get; init; }

	/// <summary>
	/// The gust speed.
	/// </summary>
	[JsonPropertyName("gust")]
	public decimal GustSpeed { get; init; }

	/// <summary>
	/// The wind speed.
	/// </summary>
	[JsonPropertyName("speed")]
	public decimal WindSpeed { get; init; }
}