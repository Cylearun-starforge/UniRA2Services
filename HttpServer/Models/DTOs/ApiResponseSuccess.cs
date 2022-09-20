namespace HttpServer.Models.DTOs;

public class ApiResponseSuccess<T>
{
	public int Code { get; } = 0;
	public T? Data { get; set; }
}