namespace Arex388.OpenWeatherMap;

internal static class RequestBaseExtensions {
	public static string GetEndpoint(
		this RequestBase request,
		OpenWeatherMapClientOptions options) => $"{request.Endpoint}&appid={options.Key}";
}