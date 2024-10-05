using System.Text.Json;
using System.Text.Json.Serialization;

namespace Arex388.OpenWeatherMap.Converters;

internal sealed class HistoricalWeatherResponseJsonConverter :
	JsonConverter<HistoricalWeather.Response> {
	public override HistoricalWeather.Response Read(
		ref Utf8JsonReader reader,
		Type typeToConvert,
		JsonSerializerOptions options) {
		var element = JsonDocument.ParseValue(ref reader).RootElement;
		var hasError = element.TryGetProperty("message", out var error);

		var weather = !hasError
			? element.Deserialize<Weather>(options)
			: null;

		weather?.Conditions.UpdateTimestamps(weather.UtcOffset);

		return new HistoricalWeather.Response {
			Error = hasError
				? error.GetString()
				: null,
			Weather = weather
		};
	}

	public override void Write(
		Utf8JsonWriter writer,
		HistoricalWeather.Response value,
		JsonSerializerOptions options) => throw new NotImplementedException();
}