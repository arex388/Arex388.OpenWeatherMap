namespace Arex388.OpenWeatherMap;

/// <summary>
/// The weather condition.
/// </summary>
public sealed class WeatherCondition {
	/// <summary>
	/// The cloudiness percentage at this time.
	/// </summary>
	public decimal? Clouds { get; init; }

	/// <summary>
	/// The dew point at which water droplets begin to condense and dew can form at this time.
	/// </summary>
	public decimal DewPoint { get; init; }

	/// <summary>
	/// The condition's details.
	/// </summary>
	public IList<WeatherConditionDetails> Details { get; init; } = [];

	/// <summary>
	/// The humidity percentage at this time.
	/// </summary>
	public decimal Humidity { get; init; }

	/// <summary>
	/// The atmospheric pressure at sea level in hectopascals (hPa) at this time.
	/// </summary>
	public int PressureAtSeaLevel { get; init; }

	/// <summary>
	/// The rain precipitation over the last hour in mm/h at this time.
	/// </summary>
	public decimal? RainPrecipitation { get; init; }

	/// <summary>
	/// The snow precipitation over the last hour in mm/h at this time.
	/// </summary>
	public decimal? SnowPrecipitation { get; init; }

	/// <summary>
	/// The local sunrise time.
	/// </summary>
	public DateTime SunriseAt { get; internal set; }

	/// <summary>
	/// The sunrise time.
	/// </summary>
	public DateTime SunriseAtUtc { get; init; }

	/// <summary>
	/// The local sunset time.
	/// </summary>
	public DateTime SunsetAt { get; internal set; }

	/// <summary>
	/// The sunset time.
	/// </summary>
	public DateTime SunsetAtUtc { get; init; }

	/// <summary>
	/// The temperature at this time.
	/// </summary>
	public decimal Temperature { get; init; }

	/// <summary>
	/// What the temperature feels like at this time.
	/// </summary>
	public decimal TemperatureFeelsLike { get; init; }

	/// <summary>
	/// The condition's local time.
	/// </summary>
	public DateTime TimestampAt { get; internal set; }

	/// <summary>
	/// The condition's time.
	/// </summary>
	public DateTime TimestampAtUtc { get; init; }

	/// <summary>
	/// The visibility distance at this time.
	/// </summary>
	public short? VisibilityDistance { get; init; }

	/// <summary>
	/// The wind's direction at this time.
	/// </summary>
	public short WindDirection { get; init; }

	/// <summary>
	/// The wind's gust speed, if any, at this time.
	/// </summary>
	public decimal? WindGustSpeed { get; init; }

	/// <summary>
	/// The wind's speed at this time.
	/// </summary>
	public decimal WindSpeed { get; init; }
}