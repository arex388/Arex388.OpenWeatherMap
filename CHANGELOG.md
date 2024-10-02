# Changelog

#### 2.0.0 (2024-10-02)

This update is a complete rewrite of the whole library. There are **many** breaking changes, but for the better, in my opinion. Overall the library should be more stable, more performant, and easier to use both for request and for reading the responses.

- **Changed:** `CurrentWeather` to be a vertical slice that contains the specific request and response objects. The slice also contains the validation rules for reading the responses.
- **Changed:** Switched from JSON.NET to System.Text.Json for better performance.
- **Added:** FluentValidation for request object validation prior to API call.
- **Added:** `IOpenWeatherMapClientFactory` for applications that need to interact with multiple Open Weather Map accounts.
- **Added:** `IServiceCollection` extensions directly into the main library.
- **Changed:** Deserialized JSON into better structured objects for easier use.
- **Changed:** Normalized behavior and naming for requests and responses.

Usage is basically the same, but you'll need to adjust the method calls and/or the request objects.