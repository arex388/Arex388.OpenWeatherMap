using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;

namespace Arex388.OpenWeatherMap.Tests;

public sealed class OpenWeatherMapClientFactoryTests {
	private readonly ITestOutputHelper _console;
	private readonly IOpenWeatherMapClientFactory _openWeatherMapFactory;

	public OpenWeatherMapClientFactoryTests(
		ITestOutputHelper console) {
		var services = new ServiceCollection().AddOpenWeatherMap().BuildServiceProvider();

		_console = console;
		_openWeatherMapFactory = services.GetRequiredService<IOpenWeatherMapClientFactory>();
	}

	[Fact]
	public void CreateAndCacheClient() {
		//	========================================================================
		//	Arrange
		//	========================================================================

		//	========================================================================
		//	Act
		//	========================================================================

		var created = _openWeatherMapFactory.CreateClient(new OpenWeatherMapClientOptions {
			Key = Config.Key,
			Units = Units.Fahrenheit
		});
		var cached = _openWeatherMapFactory.CreateClient(new OpenWeatherMapClientOptions {
			Key = Config.Key,
			Units = Units.Fahrenheit
		});

		_console.WriteLineWithHeader(nameof(created), created);
		_console.WriteLineWithHeader(nameof(cached), cached);

		//	========================================================================
		//	Assert
		//	========================================================================

		created.Should().BeSameAs(cached);
	}

	[Fact]
	public void CreateClients() {
		//	========================================================================
		//	Arrange
		//	========================================================================

		//	========================================================================
		//	Act
		//	========================================================================

		var client1 = _openWeatherMapFactory.CreateClient(new OpenWeatherMapClientOptions {
			Key = Config.Key,
			Units = Units.Fahrenheit
		});
		var client2 = _openWeatherMapFactory.CreateClient(new OpenWeatherMapClientOptions {
			Key = string.Empty,
			Units = Units.Fahrenheit
		});

		_console.WriteLineWithHeader(nameof(client1), client1);
		_console.WriteLineWithHeader(nameof(client2), client2);

		//	========================================================================
		//	Assert
		//	========================================================================

		client1.Should().NotBeSameAs(client2);
	}
}