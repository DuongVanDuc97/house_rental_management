using System.Security.Claims;
using AutoMapper;
using HR.BAL.DTOs;
using HR.BAL.DTOs.Responses;
using HR.BAL.Exceptions;
using HR.BAL.Interfaces;
using HR.DAL.Constants;
using HR.DAL.Entities;
using HR.DAL.Entities.Identity;
using HR.DAL.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace HR.BAL.Services;

public class UserService : IUserService
{
	private readonly UserManager<AppUser> _userManager;
	private readonly RoleManager<AppRole> _roleManager;
	private readonly IMapper _mapper;
	private readonly IGenericRepository<UserStatus> _statusRepository;

	public UserService(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, IMapper mapper, IGenericRepository<UserStatus> statusRepository)
	{
		_userManager = userManager;
		_roleManager = roleManager;
		_mapper = mapper;
		_statusRepository = statusRepository;
	}

	public async Task<IEnumerable<UserToReturn>> GetLandlordSignupRequest()
	{
		var users = await GetUserInRole(Role.Landlord);
		var requestedLandlords = users
			.Where(u => u.StatusId == UserStatusConstants.Requested)
			.Select(u => _mapper.Map<UserToReturn>(u));

		return requestedLandlords;
	}
	

	public async Task<IEnumerable<UserToReturn>> GetActiveLandlords()
	{
		// Get active landlords
		var activeLandlords = (await GetLandlordsAsync())
			.Where(u => u.StatusId == UserStatusConstants.Active)
			.Select(u => _mapper.Map<UserToReturn>(u));;

		return activeLandlords;
	}

	public async Task<IEnumerable<UserToReturn>> GetInactiveLandlords()
	{
		// Get inactive landlords
		var inactiveLandlords = (await GetLandlordsAsync())
			.Where(u => u.StatusId == UserStatusConstants.Inactive)
			.Select(u => _mapper.Map<UserToReturn>(u));;

		return inactiveLandlords;
	}

	public async Task<UserToReturn> UpdateUserStatus(int userId, int statusId, int staffId)
	{
		var user = await _userManager.FindByIdAsync(userId.ToString());

		if (user == null) throw new NotFoundException("User not found");
		
		var statusExists = await _statusRepository.Exists(statusId);
		
		if (!statusExists) throw new BadRequestException("Invalid Status");
		
		user.StatusId = statusId;
		
		var result = await _userManager.UpdateAsync(user);

		if (!result.Succeeded) throw new BadRequestException("Problem updating user");

		return _mapper.Map<UserToReturn>(user);
	}

	private async Task<IEnumerable<AppUser>> GetUserInRole(string roleName)
	{
		var role = await _roleManager.FindByNameAsync(roleName);
		
		if (role == null)
		{
			throw new NotFoundException("Role not found.");
		}
		
		var users = await _userManager.GetUsersInRoleAsync(roleName);
		return users;
	}
	
	private async Task<IEnumerable<AppUser>> GetLandlordsAsync()
	{
		var landlords = await GetUserInRole(Role.Landlord);
		return landlords;
	}
}