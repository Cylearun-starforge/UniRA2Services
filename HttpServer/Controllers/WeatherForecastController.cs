using HttpServer.Services;
using Microsoft.AspNetCore.Mvc;

namespace HttpServer.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class WeatherForecastController : ControllerBase
	{
		private static readonly string[] Summaries = new[]
		{
			"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
		};

		private readonly MongoService _mongoService;

		private readonly ILogger<WeatherForecastController> _logger;

		public WeatherForecastController(ILogger<WeatherForecastController> logger, MongoService mongoService)
		{
			_logger = logger;
			_mongoService = mongoService;
		}

		[HttpGet("random", Name = "GetWeatherForecast")]
		public IEnumerable<WeatherForecast> Get()
		{
			return Enumerable.Range(1, 5).Select(index => new WeatherForecast
				{
					Date = DateTime.Now.AddDays(index),
					TemperatureC = Random.Shared.Next(-20, 55),
					Summary = Summaries[Random.Shared.Next(Summaries.Length)]
				})
				.ToArray();
		}

		[HttpGet]
		public string Greeting()
		{
			_logger.LogInformation("Logger should be called once");
			return "Hello, World!";
		}
	}
}