namespace HttpServer.Models.DTOs.User;

public class GetUserResp
{
	public string Id { get; set; } = string.Empty;

	public string Name { get; set; } = string.Empty;

	public string Email { get; set; } = string.Empty;

	public IEnumerable<Achievement> Achievements { get; set; } = Array.Empty<Achievement>();

	public IEnumerable<Credits> Credits { get; set; } = Array.Empty<Credits>();

	public DateTime RegisterDateTime { get; set; } = DateTime.UtcNow;

}