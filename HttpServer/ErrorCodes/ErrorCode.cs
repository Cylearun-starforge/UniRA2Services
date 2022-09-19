using HttpServer.Models;

namespace HttpServer.ErrorCodes;

/// <summary>
/// 业务错误代码定义
/// <code> 
/// 31 30    25                         0
///  +-+-----+--------------------------+
///  |E|  M  |            C             |
///  +-+-----+--------------------------+
/// </code>
///
/// <para>
/// E: 错误类型。0：可恢复错误; 1：不可恢复错误
/// </para>
/// <para>
///	M: 错误模块
/// </para>
///	<para>
/// C: 模块错误码
/// </para>
/// </summary>
public static partial class ErrorCode
{
	public static readonly uint Ok = 0;

	public static uint MakeErrorCode(bool fatal, User error)
	{
		return MakeErrorCode(fatal, 1, (uint) error);
	}

	public static uint MakeErrorCode(bool fatal, Auth error)
	{
		return MakeErrorCode(fatal, 2, (uint) error);
	}


	private static uint MakeErrorCode(bool fatal, int module, uint code)
	{
		var codeE = fatal ? 0x80000000 : 0;
		var codeM = (uint) (module & 0x1F) << 26;
		var codeC = code & 0x03FFFFFF;
		return codeE | codeM | codeC;
	}
}