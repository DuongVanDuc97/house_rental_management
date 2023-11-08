using AutoMapper;
using HR.BAL.DTOs;
using HR.BAL.DTOs.Responses;
using HR.BAL.Exceptions;
using HR.BAL.Interfaces;
using HR.DAL.Constants;
using HR.DAL.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace HR.BAL.Services;

public class AdminService : IAdminService
{
	private readonly UserManager<AppUser> _userManager;
	private readonly RoleManager<AppRole> _roleManager;
	private readonly IMapper _mapper;

	public AdminService(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, IMapper mapper)
	{
		_userManager = userManager;
		_roleManager = roleManager;
		_mapper = mapper;
	}
	
	public async Task<StaffDto> CreateStaff(CreateStaffDto createStaffDto)
	{
		var roleStaff = await _roleManager.FindByNameAsync(Role.Staff);

		var user = new AppUser
		{
			DisplayName = createStaffDto.DisplayName,
			Email = createStaffDto.Email,
			PhoneNumber = createStaffDto.PhoneNumber,
			RoleId = roleStaff.Id,
			UserName = createStaffDto.DisplayName,
			StatusId = UserStatusConstants.Active
		};
		
		var result = await _userManager.CreateAsync(user, createStaffDto.Password);
		
		if (!result.Succeeded)
		{
			var errorMessages = string.Join(", ", result.Errors.Select(e => e.Description));
			throw new BadRequestException(errorMessages);
		}
		
		await _userManager.AddToRoleAsync(user, Role.Staff);

		return _mapper.Map<StaffDto>(user);
	}

	public Task<StaffDto> UpdateStaff(UpdateStaffDto updateStaffDto)
	{
		throw new NotImplementedException();
	}

	public Task deleteTask(int staffId)
	{
		throw new NotImplementedException();
	}
}