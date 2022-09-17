using MongoDB.Bson;
using MongoDB.Bson.Serialization;
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

	public IEnumerable<ObjectId> Friends { get; set; } = Array.Empty<ObjectId>();

	[BsonRepresentation(BsonType.String)] public byte[] PasswordHash { get; set; } = null!;

	public string Salt { get; set; } = string.Empty;

	[BsonRepresentation(BsonType.String)] public HashMethods HashMethod { get; set; } = HashMethods.Sha256;

	public IEnumerable<ObjectId> Achievements { get; set; } = Array.Empty<ObjectId>();

	public IEnumerable<ObjectId> Credits { get; set; } = Array.Empty<ObjectId>();

	public DateTime RegisterDateTime { get; set; } = DateTime.UtcNow;
}