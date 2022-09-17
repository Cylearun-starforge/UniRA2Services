using System.Text;
using HttpServer.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Security.Cryptography;

namespace HttpServerTests.Services;

[TestClass]
public class CryptoServiceTests
{
	[TestMethod]
	public void Sha256Test()
	{
		var crypto = new CryptoService();
		var encoding = new UTF8Encoding();
		var result1 = crypto.Sha256("114514", "1919810").Result;
		var result2 = crypto.Sha256("114514", "1919810").Result;
		var expect = new byte[]
		{
			0xcc, 0xef, 0xeb, 0xfe, 0x7e, 0xf3, 0xb2, 0xb4, 0xaa, 0x61, 0xf9, 0x09, 0xb9, 0x6a, 0x3e, 0xfa, 0x15, 0x3d,
			0x7a, 0x1d, 0xea, 0x68, 0xb7, 0x5b, 0x9b, 0xe9, 0x39, 0x34, 0x9f, 0x63, 0x24, 0x36
		};
		Assert.AreEqual(encoding.GetString(result1.Hash), encoding.GetString(result2.Hash));
		Assert.AreEqual(encoding.GetString(expect), encoding.GetString(result1.Hash));
	}

}