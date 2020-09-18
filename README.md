# Arex388.OpenWeatherMap

A C# client for the OpenWeatherMap API.

To use, create an instance of `OpenWeatherMapClient` and pass in an instance of `HttpClient` and your API key. The documentation can be found [here](https://openweathermap.org/api). A NuGet package is available [here](https://www.nuget.org/packages/Arex388.OpenWeatherMap/).

```c#
var openWeatherMap = new OpenWeatherMapClient(
	httpClient,
	"{key}",
	// debug = true/false
);
```

#### Current Weather

```c#
var response = await openWeatherMap.CurrentWeatherAsync(
	38.897675,
	-77.036547
);
```

