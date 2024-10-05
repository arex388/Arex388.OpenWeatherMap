using FluentValidation;
using static Arex388.OpenWeatherMap.HistoricalWeather;

namespace Arex388.OpenWeatherMap;

/// <summary>
/// The historical weather for a location.
/// </summary>
public static class HistoricalWeather {
	/// <summary>
	/// The historical weather request.
	/// </summary>
	public sealed class Request :
		RequestBase {
		internal override string Endpoint => GetEndpoint(this);

		/// <summary>
		/// The response's language.
		/// </summary>
		public string? Language { get; init; }

		/// <summary>
		/// The location's latitude.
		/// </summary>
		public required decimal Latitude { get; init; }

		/// <summary>
		/// The location's longitude.
		/// </summary>
		public required decimal Longitude { get; init; }

		/// <summary>
		/// The timestamp to check.
		/// </summary>
		public required DateTimeOffset TimestampAt { get; init; }

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
				$"dt={request.TimestampAt.ToUniversalTime().ToUnixTimeSeconds()}",
				$"units={request.Units.ToValues()}"
			};

			if (request.Language.HasValue()) {
				parameters.Add($"lang={request.Language}");
			}

			return $"3.0/onecall/timemachine?{parameters.StringJoin("&")}";
		}
	}

	/// <summary>
	/// The historical weather response.
	/// </summary>
	public sealed class Response :
		ResponseBase<Response> {
		/// <summary>
		/// The weather.
		/// </summary>
		public Weather? Weather { get; init; }
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
		RuleFor(r => r.TimestampAt).NotEmpty();
	}
}