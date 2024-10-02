namespace Arex388.OpenWeatherMap;

/// <summary>
/// Weather object.
/// </summary>
public sealed class Weather {
	/// <summary>
	/// The cloudiness percentage.
	/// </summary>
	public decimal? Clouds { get; init; }

	/// <summary>
	/// The current conditions.
	/// </summary>
	public CurrentConditions? CurrentConditions { get; init; }

	/// <summary>
	/// The condition's local timestamp.
	/// </summary>
	public DateTime? MeasuredAt => MeasuredAtUtc + UtcOffset;

	/// <summary>
	/// The condition's timestamp in UTC.
	/// </summary>
	public DateTime? MeasuredAtUtc { get; init; }

	/// <summary>
	/// Rain precipitation over the past hour in mm/h.
	/// </summary>
	public decimal? RainPrecipitation { get; init; }

	/// <summary>
	/// Snow precipitation over the past hour in mm/h.
	/// </summary>
	public decimal? SnowPrecipitation { get; init; }

	/// <summary>
	/// The local sunrise timestamp.
	/// </summary>
	public DateTime? SunriseAt => SunriseAtUtc + UtcOffset;

	/// <summary>
	/// The sunrise timestamp in UTC.
	/// </summary>
	public DateTime? SunriseAtUtc { get; init; }

	/// <summary>
	/// The local sunset timestamp.
	/// </summary>
	public DateTime? SunsetAt => SunsetAtUtc + UtcOffset;

	/// <summary>
	/// The sunset timestamp in UTC.
	/// </summary>
	public DateTime? SunsetAtUtc { get; init; }

	/// <summary>
	/// The time zone's UTC offset.
	/// </summary>
	public TimeSpan UtcOffset { get; init; } = TimeSpan.Zero;

	/// <summary>
	/// The visibility distance.
	/// </summary>
	public short? VisibilityDistance { get; init; }

	/// <summary>
	/// The weather conditions.
	/// </summary>
	public IList<WeatherConditions> WeatherConditions { get; init; } = [];

	/// <summary>
	/// The wind conditions.
	/// </summary>
	public WindConditions? WindConditions { get; init; }
}