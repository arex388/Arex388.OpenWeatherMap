using System.Text.Json.Serialization;

namespace Arex388.OpenWeatherMap;

/// <summary>
/// The current conditions.
/// </summary>
public sealed class LegacyCurrentConditions {
	/// <summary>
	/// The humidity percentage.
	/// </summary>
	[JsonIgnore]
	public decimal Humidity => HumidityRaw / 100;

	[JsonInclude, JsonPropertyName("humidity")]
	internal decimal HumidityRaw { get; init; }

	/// <summary>
	/// The atmospheric pressure at sea level in hectopascals (hPa).
	/// </summary>
	[JsonPropertyName("grnd_level")]
	public int PressureAtGroundLevel { get; init; }

	/// <summary>
	/// The atmospheric pressure at ground level in hectopascals (hPa).
	/// </summary>
	[JsonPropertyName("sea_level")]
	public int PressureAtSeaLevel { get; init; }

	/// <summary>
	/// The temperature at the moment.
	/// </summary>
	[JsonPropertyName("temp")]
	public decimal Temperature { get; init; }

	/// <summary>
	/// What the temperature feels like at the moment.
	/// </summary>
	[JsonPropertyName("feels_like")]
	public decimal TemperatureFeelsLike { get; init; }

	/// <summary>
	/// The temperature maximum at the moment.
	/// </summary>
	[JsonPropertyName("temp_max")]
	public decimal TemperatureMaximum { get; init; }

	/// <summary>
	/// The temperature minimum at the moment.
	/// </summary>
	[JsonPropertyName("temp_min")]
	public decimal TemperatureMinimum { get; init; }
}