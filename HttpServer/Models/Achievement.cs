using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace HttpServer.Models;

public class Achievement
{
	[BsonId]
	[BsonRepresentation(BsonType.ObjectId)]
	public string Id { get; set; } = null!;

	public string Content { get; set; } = string.Empty;

	public Mod FromMod { get; set; } = null!;
}