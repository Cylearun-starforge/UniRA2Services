using MongoDB.Bson;

namespace HttpServer.Extensions;

public static class StringExtension
{
	public static bool IsObjectId(
		this string id)
	{
		try
		{
			ObjectId.Parse(id);
			return true;
		}
		catch
		{
			return false;
		}
	}
}