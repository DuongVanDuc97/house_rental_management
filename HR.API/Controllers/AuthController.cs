using HR.API.Controllers.Base;
using HR.API.Reponses;
using HR.BAL.DTOs;
using HR.BAL.Interfaces;
using HR.DAL.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HR.API.Controllers;

public class AuthController : BaseApiController
{
	private readonly IAuthService _authService;

	public AuthController(IAuthService authService)
	{
		_authService = authService;
	}

	[HttpPost("login")]
	public async Task<IActionResult> Login(LoginDto loginDto)
	{
		var user = await _authService.LoginAsync(loginDto);
		return Ok(ApiResult<UserDto>.Success(user));
	}
	
	[HttpPost("register")]
	public async Task<IActionResult> Register(RegisterDto registerDto)
	{
		return Ok(ApiResult<UserDto>.Success(await _authService.RegisterAsync(registerDto)));
	}
	
}