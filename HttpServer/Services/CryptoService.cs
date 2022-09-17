using System.Security.Cryptography;
using System.Text;

namespace HttpServer.Services;

public class CryptoService
{
	private readonly SHA256 _sha256;
	private readonly UTF8Encoding _encoding;

	public class HashResult
	{
		public byte[] Hash = Array.Empty<byte>();
		public string Salt = string.Empty;
	}

	public CryptoService()
	{
		_sha256 = SHA256.Create();
		_encoding = new UTF8Encoding();
	}

	~CryptoService()
	{
		_sha256.Dispose();
	}

	public async Task<HashResult> Sha256(string data, string salt)
	{
		using var input = new MemoryStream();
		await input.WriteAsync(_encoding.GetBytes(salt));
		await input.WriteAsync(_encoding.GetBytes(data));
		var hash = DoHash(input, _sha256);
		return new HashResult
		{
			Hash = hash,
			Salt = salt
		};
	}

	private static byte[] DoHash(Stream inputStream, HashAlgorithm algorithm)
	{
		var result = algorithm.ComputeHash(inputStream);
		return result;
	}
}