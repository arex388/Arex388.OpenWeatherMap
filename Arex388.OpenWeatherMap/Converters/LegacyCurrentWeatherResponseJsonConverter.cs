using System.Text.Json;
using System.Text.Json.Serialization;

namespace Arex388.OpenWeatherMap.Converters;

internal sealed class LegacyCurrentWeatherResponseJsonConverter :
	JsonConverter<LegacyCurrentWeather.Response> {
	public override LegacyCurrentWeather.Response Read(
		ref Utf8JsonReader reader,
		Type typeToConvert,
		JsonSerializerOptions options) {
		var element = JsonDocument.ParseValue(ref reader).RootElement;
		var hasError = element.TryGetProperty("message", out var error);

		return new LegacyCurrentWeather.Response {
			Error = hasError
				? error.GetString()
				: null,
			Weather = !hasError
				? element.Deserialize<LegacyWeather>(options)
				: null
		};
	}

	public override void Write(
		Utf8JsonWriter writer,
		LegacyCurrentWeather.Response value,
		JsonSerializerOptions options) => throw new NotImplementedException();
}