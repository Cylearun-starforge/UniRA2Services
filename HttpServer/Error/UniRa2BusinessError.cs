namespace HttpServer.Error;

public class UniRa2BusinessError : Exception
{
	public uint Code;
	public string Msg = string.Empty;
}