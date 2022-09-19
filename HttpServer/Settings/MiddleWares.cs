using HttpServer.MiddleWares;

namespace HttpServer.Settings;

public static class MiddleWaresExtension
{
	public static IApplicationBuilder UseBusinessMiddleWares(
		this IApplicationBuilder builder)
	{
		builder.UseBusinessErrorHandler();
		return builder;
	}
}