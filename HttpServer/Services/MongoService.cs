using HttpServer.Settings.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace HttpServer.Services;

public class MongoService
{
	private MongoClient _client;
	private IMongoDatabase _db;

	public MongoService(IOptions<DatabaseSetting> mongoOptions)
	{
		_client = new MongoClient(new MongoUrl(mongoOptions.Value.ConnectionUrl));
		_db = _client.GetDatabase(mongoOptions.Value.DatabaseName);
	}

	public IMongoCollection<T> GetCollection<T>(string collection, MongoCollectionSettings? settings = null)
	{
		return _db.GetCollection<T>(collection, settings);
	}
}