namespace Arex388.OpenWeatherMap;

internal static class WeatherConditionExtensions {
	public static void UpdateTimestamps(
		this IList<WeatherCondition> conditions,
		TimeSpan utcOffset) {
		foreach (var condition in conditions) {
			condition.SunriseAt = condition.SunriseAtUtc + utcOffset;
			condition.SunsetAt = condition.SunsetAtUtc + utcOffset;
			condition.TimestampAt = condition.TimestampAtUtc + utcOffset;
		}
	}
}