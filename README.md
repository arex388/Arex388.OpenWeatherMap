# Arex388.OpenWeatherMap

> [!CAUTION]
>
> This README refers to the v3.0.0 version of the library only.



Arex388.OpenWeatherMap is a highly opinionated .NET Standard 2.0 library for the [Open Weather Map](https://openweathermap.org/current) API. It is intended to an easy, well structured, and highly performant client for interacting with the Open Weather Map API. It can be used in applications interacting with a single account using `IOpenWeatherMapClient`, or with applications interacting with multiple accounts using `IOpenWeatherMapClientFactory`.

- [Changelog](CHANGELOG.md)



#### Dependency Injection

To configure dependency inject use the `AddOpenWeatherMap()` extensions on `IServiceCollection`. There are two signatures, with and without passing in a `OpenWeatherMapClientOptions` object. If the options objects is passed to the extension, it will register `IOpenWeatherMapClient` for use with a single account, otherwise it will register `IOpenWeatherMapClientFactory` for use with multiple accounts.



#### How to Use

For a single account, inject the `IOpenWeatherMapClient`.

```c#
private readonly IOpenWeatherMapClient _openWeatherMap;

_ = await _openWeatherMap.LegacyCurrentWeatherAsync(38.897675, -77.036547);
```



For multiple accounts, inject the `IOpenWeatherMapClientFactory` to create an instance per account.

```c#
private readonly IOpenWeatherMapClientFactory _openWeatherMapFactory;

var openWeatherMap = _openWeatherMapFactory.CreateClient(new OpenWeatherMapClient {
	Key = "Your key from Open Weather Map"
});

_ = await _openWeatherMap.LegacyCurrentWeatherAsync(38.897675, -77.036547);
```



> [!NOTE]
>
> I've only implemented the Current Weather endpoint because that's all I've needed. If you want something more you can either open an issue, and I'll implement it when I have a chance, or you can do a pull request that follows the style of the library, or you can fork it an implement it yourself. I would prefer if you open an issue for it and let me do it.



The client provides methods for interacting with Current Weather using the following methods:

###### Historical Weather

- `HistoricalWeatherAsync()` - Get the historical weather for a location.



###### Current Weather (Legacy)

- `LegacyCurrentWeatherAsync()` - Get the current weather for a location.
