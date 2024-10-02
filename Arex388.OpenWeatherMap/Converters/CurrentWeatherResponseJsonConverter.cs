using System.Text.Json;
using System.Text.Json.Serialization;

namespace Arex388.OpenWeatherMap.Converters;

internal sealed class CurrentWeatherResponseJsonConverter :
	JsonConverter<CurrentWeather.Response> {
	public override CurrentWeather.Response Read(
		ref Utf8JsonReader reader,
		Type typeToConvert,
		JsonSerializerOptions options) {
		var element = JsonDocument.ParseValue(ref reader).RootElement;
		var hasError = element.TryGetProperty("message", out var error);

		return new CurrentWeather.Response {
			Error = hasError
				? error.GetString()
				: null,
			Weather = !hasError
				? element.Deserialize<Weather>(options)
				: null
		};
	}

	public override void Write(
		Utf8JsonWriter writer,
		CurrentWeather.Response value,
		JsonSerializerOptions options) => throw new NotImplementedException();
}