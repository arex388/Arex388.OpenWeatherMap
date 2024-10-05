using System.Text.Json;
using System.Text.Json.Serialization;

namespace Arex388.OpenWeatherMap.Converters;

internal sealed class WeatherJsonConverter :
	JsonConverter<Weather> {
	public override Weather Read(
		ref Utf8JsonReader reader,
		Type typeToConvert,
		JsonSerializerOptions options) {
		var element = JsonDocument.ParseValue(ref reader).RootElement;
		var hasTimezoneUtcOffset = element.TryGetProperty("timezone_offset", out var timezoneUtcOffset);

		return new Weather {
			Conditions = element.GetProperty("data").Deserialize<IList<WeatherCondition>>(options) ?? [],
			UtcOffset = hasTimezoneUtcOffset
				? TimeSpan.FromSeconds(timezoneUtcOffset.GetInt16())
				: TimeSpan.Zero
		};
	}

	public override void Write(
		Utf8JsonWriter writer,
		Weather value,
		JsonSerializerOptions options) => throw new NotImplementedException();
}