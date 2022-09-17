using HttpServer.Models;
using MongoDB.Driver;

namespace HttpServer.Services;

public class UserService
{
	private readonly MongoService _mongo;
	private readonly CryptoService _crypto;

	public UserService(MongoService mongo, CryptoService crypto)
	{
		_mongo = mongo;
		_crypto = crypto;
	}

	public IMongoCollection<User> GetUsers()
	{
		return _mongo.GetCollection<User>();
	}

	public async void CreateUser()
	{
		var hash = await _crypto.Sha256("123456", "123456");
		await _mongo.GetCollection<User>().InsertOneAsync(new User
		{
			Name = "Woodykaixa",
			Email = "690750353@qq.com",
			PasswordHash = hash.Hash,
			Salt = hash.Salt,
		});
	}
}