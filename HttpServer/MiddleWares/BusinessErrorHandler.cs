using System.Text.Json;
using HttpServer.Error;
using HttpServer.Models.DTOs;

namespace HttpServer.MiddleWares;

public class BusinessErrorHandlerMiddleware
{
	private readonly RequestDelegate _next;
	private readonly JsonSerializerOptions _serializerOptions;

	public BusinessErrorHandlerMiddleware(RequestDelegate next)
	{
		_next = next;
		_serializerOptions = new JsonSerializerOptions
		{
			PropertyNamingPolicy = JsonNamingPolicy.CamelCase
		};
	}

	public async Task InvokeAsync(HttpContext context)
	{
		try
		{
			await _next(context);
		}
		catch (UniRa2BusinessError e)
		{
			context.Response.ContentType = "application/json";
			var errorResp = JsonSerializer.SerializeToUtf8Bytes(new ApiResponseFailed
			{
				Code = (int) e.Code,
				Msg = e.Msg
			}, _serializerOptions);

			context.Response.StatusCode = 200;
			var result = await context.Response.BodyWriter.WriteAsync(errorResp);
			if (result.IsCompleted)
			{
				throw new Exception("Failed to flush");
			}
		}
	}
}

public static class BusinessErrorHandlerMiddlewareExtension
{
	public static IApplicationBuilder UseBusinessErrorHandler(
		this IApplicationBuilder builder)
	{
		return builder.UseMiddleware<BusinessErrorHandlerMiddleware>();
	}
}