using System.Text.Json;
using System.Text.Json.Serialization;

namespace Arex388.OpenWeatherMap.Converters;

internal sealed class WeatherConditionJsonConverter :
	JsonConverter<WeatherCondition> {
	public override WeatherCondition Read(
		ref Utf8JsonReader reader,
		Type typeToConvert,
		JsonSerializerOptions options) {
		var element = JsonDocument.ParseValue(ref reader).RootElement;
		var hasClouds = element.TryGetProperty("clouds", out var clouds);
		var hasRainPrecipitation = element.TryGetProperty("rain", out var rainPrecipitation);
		var hasSnowPrecipitation = element.TryGetProperty("snow", out var snowPrecipitation);
		var hasVisibilityDistance = element.TryGetProperty("visibility", out var visibilityDistance);
		var hasWindGustSpeed = element.TryGetProperty("wind_gust", out var windGustSpeed);

		return new WeatherCondition {
			Clouds = hasClouds
				? clouds.GetDecimal()
				: null,
			DewPoint = element.GetProperty("dew_point").GetDecimal(),
			Details = element.GetProperty("weather").Deserialize<IList<WeatherConditionDetails>>() ?? [],
			Humidity = element.GetProperty("humidity").GetByte() / 100M,
			PressureAtSeaLevel = element.GetProperty("pressure").GetInt32(),
			RainPrecipitation = hasRainPrecipitation
				? rainPrecipitation.GetProperty("1h").GetDecimal()
				: null,
			SnowPrecipitation = hasSnowPrecipitation
				? snowPrecipitation.GetProperty("1h").GetDecimal()
				: null,
			SunriseAtUtc = DateTimeOffset.FromUnixTimeSeconds(element.GetProperty("sunrise").GetInt32()).DateTime,
			SunsetAtUtc = DateTimeOffset.FromUnixTimeSeconds(element.GetProperty("sunset").GetInt32()).DateTime,
			Temperature = element.GetProperty("temp").GetDecimal(),
			TemperatureFeelsLike = element.GetProperty("feels_like").GetDecimal(),
			TimestampAtUtc = DateTimeOffset.FromUnixTimeSeconds(element.GetProperty("dt").GetInt32()).DateTime,
			VisibilityDistance = hasVisibilityDistance
				? visibilityDistance.GetInt16()
				: null,
			WindDirection = element.GetProperty("wind_deg").GetInt16(),
			WindGustSpeed = hasWindGustSpeed
				? windGustSpeed.GetDecimal()
				: null,
			WindSpeed = element.GetProperty("wind_speed").GetDecimal()
		};
	}

	public override void Write(
		Utf8JsonWriter writer,
		WeatherCondition value,
		JsonSerializerOptions options) => throw new NotImplementedException();
}