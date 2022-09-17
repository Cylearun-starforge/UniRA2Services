using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace HttpServer.Models;

public class User
{
	public enum HashMethods
	{
		Sha256
	}

	[BsonId]
	[BsonRepresentation(BsonType.ObjectId)]
	public string Id { get; set; } = null!;

	public string Name { get; set; } = null!;

	public string Email { get; set; } = null!;

	public IEnumerable<User> Friends { get; set; } = Array.Empty<User>();

	public string PasswordHash { get; set; } = null!;

	[BsonRepresentation(BsonType.String)] public HashMethods HashMethod { get; set; } = HashMethods.Sha256;

	public IEnumerable<Achievement> Achievements { get; set; } = Array.Empty<Achievement>();

	public IEnumerable<Credits> Credits { get; set; } = Array.Empty<Credits>();
}