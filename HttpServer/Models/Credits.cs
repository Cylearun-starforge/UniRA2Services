using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace HttpServer.Models;

public class Credits
{
	[BsonId]
	[BsonRepresentation(BsonType.ObjectId)]
	public string Id { get; set; } = null!;
}