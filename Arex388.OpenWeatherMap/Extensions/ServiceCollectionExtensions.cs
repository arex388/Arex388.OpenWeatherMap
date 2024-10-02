using Arex388.OpenWeatherMap;
using FluentValidation;

namespace Microsoft.Extensions.DependencyInjection;

/// <summary>
/// <see cref="IServiceCollection"/> extensions.
/// </summary>
public static class ServiceCollectionExtensions {
	/// <summary>
	/// Add the Open Weather Map API client factory for interacting with multiple accounts.
	/// </summary>
	/// <param name="services">The services collection.</param>
	/// <returns>The services collection.</returns>
	public static IServiceCollection AddOpenWeatherMap(
		this IServiceCollection services) => services.AddHttpClient()
													 .AddMemoryCache()
													 .AddValidatorsFromAssemblyContaining<IOpenWeatherMapClient>(includeInternalTypes: true, lifetime: ServiceLifetime.Singleton)
													 .AddSingleton<IOpenWeatherMapClientFactory, OpenWeatherMapClientFactory>();

	/// <summary>
	/// Add the Open Weather Map API client for interacting with a single account.
	/// </summary>
	/// <param name="services">The services collection.</param>
	/// <param name="options">The client's configuration options.</param>
	/// <returns>The services collection.</returns>
	public static IServiceCollection AddOpenWeatherMap(
		this IServiceCollection services,
		OpenWeatherMapClientOptions options) {
		services.AddHttpClient<IOpenWeatherMapClient>(
			hc => hc.BaseAddress = HttpClientHelper.BaseAddress);

		return services.AddValidatorsFromAssemblyContaining<IOpenWeatherMapClient>(includeInternalTypes: true, lifetime: ServiceLifetime.Singleton)
					   .AddSingleton(options)
					   .AddSingleton<IOpenWeatherMapClient>(
						   sp => new OpenWeatherMapClient(sp));
	}
}