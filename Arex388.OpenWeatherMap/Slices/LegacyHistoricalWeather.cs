//using FluentValidation;
//using System.Text.Json.Serialization;
//using static Arex388.OpenWeatherMap.HistoricalWeather;

//namespace Arex388.OpenWeatherMap;

///// <summary>
///// Historical weather for a location.
///// </summary>
//public static class HistoricalWeather {
//	/// <summary>
//	/// Historical weather request.
//	/// </summary>
//	public sealed class Request :
//		RequestBase {
//		/// <summary>
//		/// The timestamp to stop at.
//		/// </summary>
//		public required DateTimeOffset EndAt { get; init; }

//		internal override string Endpoint => GetEndpoint(this);

//		/// <summary>
//		/// The location's latitude.
//		/// </summary>
//		public required decimal Latitude { get; init; }

//		/// <summary>
//		/// The location's longitude.
//		/// </summary>
//		public required decimal Longitude { get; init; }

//		/// <summary>
//		/// The timestamp to start at.
//		/// </summary>
//		public required DateTimeOffset StartAt { get; init; }

//		/// <summary>
//		/// The number of results to return.
//		/// </summary>
//		public int? Take { get; init; }

//		/// <summary>
//		/// The response's unit of measurement.
//		/// </summary>
//		public Units Units { get; init; } = Units.Default;

//		//	========================================================================
//		//	Utilities
//		//	========================================================================

//		private static string GetEndpoint(
//			Request request) {
//			var parameters = new HashSet<string> {
//				$"end={request.EndAt.ToUniversalTime().ToUnixTimeSeconds()}",
//				$"lat={request.Latitude}",
//				$"lon={request.Longitude}",
//				$"start={request.StartAt.ToUniversalTime().ToUnixTimeSeconds()}",
//				"type=hour",
//				$"units={request.Units.ToValues()}"
//			};

//			if (request.Take.HasValue) {
//				parameters.Add($"cnt={request.Take}");
//			}

//			return $"history/city?{parameters.StringJoin("&")}";
//		}
//	}

//	/// <summary>
//	/// Histical weather response.
//	/// </summary>
//	public sealed class Response :
//		ResponseBase<Response> {
//		/// <summary>
//		/// The weather.
//		/// </summary>
//		[JsonPropertyName("list")]
//		public IList<Weather> Weathers { get; init; } = [];
//	}
//}

////	================================================================================
////	Validators
////	================================================================================

//file sealed class RequestValidator :
//	AbstractValidator<Request> {
//	public RequestValidator() {
//		RuleFor(r => r.EndAt).Must((r, dt) => dt > r.StartAt).NotEmpty();
//		RuleFor(r => r.Latitude).GreaterThanOrEqualTo(-90).LessThanOrEqualTo(90).NotEmpty();
//		RuleFor(r => r.Longitude).GreaterThanOrEqualTo(-180).LessThanOrEqualTo(180).NotEmpty();
//		RuleFor(r => r.StartAt).NotEmpty();
//	}
//}