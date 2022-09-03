using HttpServer.Controllers;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace HttpServerTests.Controllers
{
	[TestClass()]
	public class WeatherForecastControllerTests
	{
		[TestMethod()]
		public void GreetingTest()
		{
			var logger = new Mock<ILogger<WeatherForecastController>>();
			var controller = new WeatherForecastController(logger.Object);
			var greeting = controller.Greeting();
			Assert.AreEqual("Hello, World!", greeting);
			Assert.AreEqual(1, logger.Invocations.Count);
			Assert.AreEqual("Log", logger.Invocations[0].Method.Name);
		}
	}
}