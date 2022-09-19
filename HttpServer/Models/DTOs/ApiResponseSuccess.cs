namespace HttpServer.Models.DTOs;

public class ApiResponseSuccess<T>
{
	public const int Code = 0;
	public T? Data { get; set; }
}