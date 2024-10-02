using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;

namespace Arex388.OpenWeatherMap.Tests;

public sealed class CurrentWeatherTests {
	private readonly ITestOutputHelper _console;
	private readonly IOpenWeatherMapClient _openWeatherMap;

	public CurrentWeatherTests(
		ITestOutputHelper console) {
		var services = new ServiceCollection().AddOpenWeatherMap(new OpenWeatherMapClientOptions {
			Key = Config.Key
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

		var currentWeather = await _openWeatherMap.CurrentWeatherAsync(38.897675M, -77.036547M, Units.Default);

		_console.WriteLineWithHeader(nameof(currentWeather), currentWeather);

		//	========================================================================
		//	Assert
		//	========================================================================

		currentWeather.Errors.Should().BeEmpty();
		currentWeather.Success.Should().BeTrue();
	}
}