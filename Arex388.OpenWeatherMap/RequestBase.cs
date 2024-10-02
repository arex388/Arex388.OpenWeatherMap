namespace Arex388.OpenWeatherMap;

/// <summary>
/// The request's base details.
/// </summary>
public abstract class RequestBase {
	internal abstract string Endpoint { get; }
}