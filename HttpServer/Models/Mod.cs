using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace HttpServer.Models;

public class Mod
{
	[BsonId]
	[BsonRepresentation(BsonType.ObjectId)]
	public string Id { get; set; } = null!;

	public string Name { get; set; } = null!;

	public Credits Publisher { get; set; } = null!;

	public string Description { get; set; } = null!;
}