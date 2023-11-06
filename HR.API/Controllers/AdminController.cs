using HR.API.Controllers.Base;
using HR.API.Reponses;
using HR.BAL.DTOs;
using HR.BAL.DTOs.Responses;
using HR.BAL.Interfaces;
using HR.DAL.Constants;
using HR.DAL.Entities.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HR.API.Controllers;

[Authorize(Roles = Role.Administrator)]
public class AdminController : BaseApiController
{
	private readonly IAdminService _adminService;

	public AdminController(IAdminService adminService)
	{
		_adminService = adminService;
	}

	[HttpPost("staff")]
	public async Task<ActionResult<StaffDto>> CreateStaff(CreateStaffDto createStaffDto)
	{
		var staff = await _adminService.CreateStaff(createStaffDto);
		return Ok(ApiResult<StaffDto>.Success(staff));
	}
}