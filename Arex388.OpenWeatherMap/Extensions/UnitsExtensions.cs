namespace Arex388.OpenWeatherMap;

internal static class UnitsExtensions {
	public static string ToValues(
		this Units units) => units switch {
			Units.Celsius => "metric",
			Units.Fahrenheit => "imperial",
			_ => "standard"
		};
}