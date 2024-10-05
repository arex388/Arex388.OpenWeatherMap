using System.Text.Json.Serialization;

namespace Arex388.OpenWeatherMap;

/// <summary>
/// The weather conditions.
/// </summary>
public sealed class LegacyWeatherConditions {
	/// <summary>
	/// The condition's description.
	/// </summary>
	public string Description { get; init; } = null!;

	/// <summary>
	/// The condition's id.
	/// </summary>
	public int Id { get; init; }

	/// <summary>
	/// The condition's name.
	/// </summary>
	[JsonPropertyName("main")]
	public string Name { get; init; } = null!;
}