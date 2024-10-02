using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;

namespace Arex388.OpenWeatherMap;

internal sealed class OpenWeatherMapClientFactory(
	IServiceProvider services,
	IMemoryCache cache) :
	IOpenWeatherMapClientFactory {
	private static readonly MemoryCacheEntryOptions _cacheEntryOptions = new() {
		SlidingExpiration = TimeSpan.MaxValue
	};

	private readonly IServiceProvider _services = services;
	private readonly IMemoryCache _cache = cache;

	public IOpenWeatherMapClient CreateClient(
		OpenWeatherMapClientOptions options) {
		var key = $"{nameof(Arex388)}.{nameof(OpenWeatherMap)}.Key[{options.Key}]";

		if (_cache.TryGetValue(key, out IOpenWeatherMapClient? openWeatherMapClient)
			&& openWeatherMapClient is not null) {
			return openWeatherMapClient;
		}

		var httpClientFactory = _services.GetRequiredService<IHttpClientFactory>();
		var httpClient = httpClientFactory.CreateClient(nameof(IOpenWeatherMapClient));

		httpClient.BaseAddress = HttpClientHelper.BaseAddress;

		openWeatherMapClient = new OpenWeatherMapClient(_services, httpClient, options);

		_cache.Set(key, openWeatherMapClient, _cacheEntryOptions);

		return openWeatherMapClient;
	}
}