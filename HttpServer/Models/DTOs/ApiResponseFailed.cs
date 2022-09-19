namespace HttpServer.Models.DTOs;

public class ApiResponseFailed
{
	public int Code { get; set; }
	public string Msg { get; set; } = string.Empty;
}