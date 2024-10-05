using System.Text.Json;
using System.Text.Json.Serialization;

namespace Arex388.OpenWeatherMap.Converters;

internal sealed class LegacyWeatherJsonConverter :
	JsonConverter<LegacyWeather> {
	public override LegacyWeather Read(
		ref Utf8JsonReader reader,
		Type typeToConvert,
		JsonSerializerOptions options) {
		var element = JsonDocument.ParseValue(ref reader).RootElement;
		var hasClouds = element.TryGetProperty("clouds", out var clouds);
		var hasCurrentConditions = element.TryGetProperty("main", out var currentConditions);
		var hasMeasuredAtUtc = element.TryGetProperty("dt", out var measuredAtUtc);
		var hasRainPrecipitation = element.TryGetProperty("rain", out var rainPrecipitation);
		var hasSnowPrecipitation = element.TryGetProperty("snow", out var snowPrecipitation);
		var hasMetadata = element.TryGetProperty("sys", out var metadata);
		var hasUtcOffset = element.TryGetProperty("timezone", out var utcOffset);
		var hasVisibilityDistance = element.TryGetProperty("visibility", out var visibilityDistance);
		var hasWeatherConditions = element.TryGetProperty("weather", out var weatherConditions);
		var hasWindConditions = element.TryGetProperty("wind", out var windConditions);

		return new LegacyWeather {
			Clouds = hasClouds
				? clouds.GetProperty("all").GetDecimal()
				: null,
			CurrentConditions = hasCurrentConditions
				? currentConditions.Deserialize<LegacyCurrentConditions>(options)!
				: null,
			MeasuredAtUtc = hasMeasuredAtUtc
				? DateTimeOffset.FromUnixTimeSeconds(measuredAtUtc.GetInt32()).DateTime
				: null,
			RainPrecipitation = hasRainPrecipitation
				? rainPrecipitation.GetProperty("1h").GetDecimal()
				: null,
			SnowPrecipitation = hasSnowPrecipitation
				? snowPrecipitation.GetProperty("1h").GetDecimal()
				: null,
			SunriseAtUtc = hasMetadata
				? DateTimeOffset.FromUnixTimeSeconds(metadata.GetProperty("sunrise").GetInt32()).DateTime
				: null,
			SunsetAtUtc = hasMetadata
				? DateTimeOffset.FromUnixTimeSeconds(metadata.GetProperty("sunset").GetInt32()).DateTime
				: null,
			UtcOffset = hasUtcOffset
				? TimeSpan.FromSeconds(utcOffset.GetInt16())
				: TimeSpan.Zero,
			VisibilityDistance = hasVisibilityDistance
				? visibilityDistance.GetInt16()
				: null,
			WeatherConditions = hasWeatherConditions
				? weatherConditions.Deserialize<IList<LegacyWeatherConditions>>(options)!
				: [],
			WindConditions = hasWindConditions
				? windConditions.Deserialize<LegacyWindConditions>(options)!
				: null
		};
	}

	public override void Write(
		Utf8JsonWriter writer,
		LegacyWeather value,
		JsonSerializerOptions options) => throw new NotImplementedException();
}