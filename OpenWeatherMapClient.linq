<Query Kind="Program">
  <Reference Relative="Arex388.OpenWeatherMap\bin\Debug\netstandard2.0\Arex388.OpenWeatherMap.dll">E:\Software Development\Arex388.OpenWeatherMap\Arex388.OpenWeatherMap\bin\Debug\netstandard2.0\Arex388.OpenWeatherMap.dll</Reference>
  <NuGetReference>Microsoft.Extensions.Http</NuGetReference>
  <Namespace>Arex388.OpenWeatherMap</Namespace>
  <Namespace>Microsoft.Extensions.DependencyInjection</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

private static readonly OpenWeatherMapClientOptions _options = new OpenWeatherMapClientOptions {
	Key = Util.GetPassword("openweathermap.key")
};

async Task Main() {
	//var openWeatherMap = GetClientMultiple();
	//var openWeatherMap = GetClientSingle();
}

public IOpenWeatherMapClient GetClientMultiple() {
	var services = new ServiceCollection().AddOpenWeatherMap().BuildServiceProvider();
	var openWeatherMapFactory = services.GetRequiredService<IOpenWeatherMapClientFactory>();

	return openWeatherMapFactory.CreateClient(_options);
}

public IOpenWeatherMapClient GetClientSingle() {
	var services = new ServiceCollection().AddOpenWeatherMap(_options).BuildServiceProvider();

	return services.GetRequiredService<IOpenWeatherMapClient>();
}

//	============================================================================
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//	EoF