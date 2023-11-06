using System.Security.Claims;
using HR.API.Controllers.Base;
using HR.API.Extensions;
using HR.API.Reponses;
using HR.BAL.DTOs.Responses;
using HR.BAL.Interfaces;
using HR.DAL.Constants;
using HR.DAL.Entities.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HR.API.Controllers;

[Authorize(Roles = Role.Staff)]
public class UserController : BaseApiController
{
	private readonly IUserService _userService;
	private readonly UserManager<AppUser> _userManager;

	public UserController(IUserService userService, UserManager<AppUser> userManager)
	{
		_userService = userService;
		_userManager = userManager;
	}

	[HttpGet("landlordRequested")]
	public async Task<IActionResult> GetLandlordSignupRequest()
	{
		var landlords = await _userService.GetLandlordSignupRequest();
		return Ok(ApiResult<IEnumerable<UserToReturn>>.Success(landlords));
	}

	[HttpGet("activeLanlords")]
	public async Task<IActionResult> GetActiveLandlords()
	{
		var landlords = await _userService.GetActiveLandlords();
		return Ok(ApiResult<IEnumerable<UserToReturn>>.Success(landlords));
	}
	
	[HttpGet("inactiveLanlords")]
	public async Task<IActionResult> GetInactiveLandlords()
	{
		return Ok(await _userService.GetInactiveLandlords());
	}

	[HttpPut("status/{userId}/{statusId}")]
	public async Task<IActionResult> UpdateUserStatus(int userId, int statusId)
	{
		var staff = await _userManager.FindByEmailFromClaimsPrincipal(User);
		var user = await _userService.UpdateUserStatus(userId, statusId, staff.Id);
		return Ok(ApiResult<UserToReturn>.Success(user));
	}
}