using FluentValidation;
using static Arex388.OpenWeatherMap.LegacyCurrentWeather;

namespace Arex388.OpenWeatherMap;

/// <summary>
/// Current weather for a location.
/// </summary>
public static class LegacyCurrentWeather {
	/// <summary>
	/// Current weather request.
	/// </summary>
	public sealed class Request :
		RequestBase {
		internal override string Endpoint => GetEndpoint(this);

		/// <summary>
		/// The location's latitude.
		/// </summary>
		public required decimal Latitude { get; init; }

		/// <summary>
		/// The location's longitude.
		/// </summary>
		public required decimal Longitude { get; init; }

		/// <summary>
		/// The response's unit of measurement.
		/// </summary>
		public Units Units { get; init; } = Units.Default;

		//	========================================================================
		//	Utilities
		//	========================================================================

		private static string GetEndpoint(
			Request request) {
			var parameters = new HashSet<string> {
				$"lat={request.Latitude}",
				$"lon={request.Longitude}",
				$"units={request.Units.ToValues()}"
			};

			return $"2.5/weather?{parameters.StringJoin("&")}";
		}
	}

	/// <summary>
	/// Current weather response.
	/// </summary>
	public sealed class Response :
		ResponseBase<Response> {
		/// <summary>
		/// The weather.
		/// </summary>
		public LegacyWeather? Weather { get; init; }
	}
}

//	================================================================================
//	Validators
//	================================================================================

file sealed class RequestValidator :
	AbstractValidator<Request> {
	public RequestValidator() {
		RuleFor(r => r.Latitude).GreaterThanOrEqualTo(-90).LessThanOrEqualTo(90).NotEmpty();
		RuleFor(r => r.Longitude).GreaterThanOrEqualTo(-180).LessThanOrEqualTo(180).NotEmpty();
	}
}