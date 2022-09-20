using HttpServer.Error;
using HttpServer.ErrorCodes;
using HttpServer.Models;
using HttpServer.Models.DTOs;
using HttpServer.Models.DTOs.User;
using HttpServer.Services;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;

namespace HttpServer.Controllers;

[Route("[controller]")]
[ApiController]
public class UserController : ControllerBase
{
	private readonly UserService _userService;

	public UserController(UserService userService)
	{
		_userService = userService;
	}

	[HttpGet("{id:length(24)}")]
	public async Task<ApiResponseSuccess<GetUserResp>> GetUserById(string id)
	{
		try
		{
			var user = _userService.GetUsers().AsQueryable().First(user => user.Id == id);
			var userResp = new GetUserResp()
			{
				Id = user.Id,
				Name = user.Name,
				Email = user.Email,
				RegisterDateTime = user.RegisterDateTime
			};
			return new ApiResponseSuccess<GetUserResp>
			{
				Data = userResp
			};
		}
		catch (InvalidOperationException)
		{
			throw new UniRa2BusinessError
			{
				Code = ErrorCode.MakeErrorCode(true, ErrorCode.User.NotFound)
			};
		}
	}

	// POST api/<UserController>
	[HttpPost]
	public ApiResponseSuccess<object> Post([FromBody] string value)
	{
		_userService.CreateUser();
		return new ApiResponseSuccess<object> {Data = new object()};
	}
}