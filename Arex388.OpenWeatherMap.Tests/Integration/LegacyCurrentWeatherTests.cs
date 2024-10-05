using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;

namespace Arex388.OpenWeatherMap.Tests;

public sealed class LegacyCurrentWeatherTests {
	private readonly ITestOutputHelper _console;
	private readonly IOpenWeatherMapClient _openWeatherMap;

	public LegacyCurrentWeatherTests(
		ITestOutputHelper console) {
		var services = new ServiceCollection().AddOpenWeatherMap(new OpenWeatherMapClientOptions {
			Key = Config.Key,
			Units = Units.Fahrenheit
		}).BuildServiceProvider();

		_console = console;
		_openWeatherMap = services.GetRequiredService<IOpenWeatherMapClient>();
	}

	[Fact]
	public async Task Single_Succeeds() {
		//	========================================================================
		//	Arrange
		//	========================================================================

		//	========================================================================
		//	Act
		//	========================================================================

		var currentWeather = await _openWeatherMap.LegacyCurrentWeatherAsync(38.897675M, -77.036547M);

		_console.WriteLineWithHeader(nameof(currentWeather), currentWeather);

		//	========================================================================
		//	Assert
		//	========================================================================

		currentWeather.Errors.Should().BeEmpty();
		currentWeather.Success.Should().BeTrue();
	}
}