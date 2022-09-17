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
		Assert.AreEqual(encoding.GetString(result1.Hash), encoding.GetString(result2.Hash));
	}

}