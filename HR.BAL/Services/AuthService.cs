using System.Security.Authentication;
using AutoMapper;
using HR.BAL.DTOs;
using HR.BAL.Exceptions;
using HR.BAL.Interfaces;
using HR.DAL.Constants;
using HR.DAL.Data;
using HR.DAL.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HR.BAL.Services;

public class AuthService : IAuthService
{
	private readonly UserManager<AppUser> _userManager;
	private readonly RoleManager<AppRole> _roleManager;
	private readonly ITokenService _tokenService;
	private readonly SignInManager<AppUser> _signInManager;
	private readonly IMapper _mapper;

	public AuthService(
		UserManager<AppUser> userManager,
		RoleManager<AppRole> roleManager,
		ITokenService tokenService, 
		SignInManager<AppUser> signInManager, 
		IMapper mapper
		)
	{
		_userManager = userManager;
		_roleManager = roleManager;
		_tokenService = tokenService;
		_signInManager = signInManager;
		_mapper = mapper;
	}
	public async Task<UserDto> LoginAsync(LoginDto loginDto)
	{
		var user = await _userManager.FindByEmailAsync(loginDto.Email);

		if (user == null) throw new NotFoundException("Email or Password is incorrect");

		var signInResult = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

		if (!signInResult.Succeeded) throw new BadRequestException("Email or Password is incorrect");

		var token = await _tokenService.CreateToken(user);
		
		return new UserDto
		{
			Email = user.Email,
			DisplayName = user.DisplayName,
			Token = token
		};
	}

	public async Task<UserDto> RegisterAsync(RegisterDto registerDto)
	{
		if (await UserExists(registerDto.Email)) throw new BadRequestException("Email already exist");
		
		if (string.IsNullOrEmpty(registerDto.RoleName)) throw new BadRequestException($"Role can not be empty.");
		
		var role = await _roleManager.FindByNameAsync(registerDto.RoleName);
		
		if (role == null) throw new BadRequestException($"Role '{registerDto.RoleName}' does not exist.");
		
		// var roleExists = await _roleManager.RoleExistsAsync(registerDto.RoleName);
		//
		// if (!roleExists) throw new BadRequestException($"Role '{registerDto.RoleName}' does not exist.");
		
		var user = _mapper.Map<AppUser>(registerDto);
		
		user.UserName = user.DisplayName;
		// Assign the roleId property
		user.RoleId = role.Id;
		
		if (registerDto.RoleName == Role.Landlord)
		{
			user.StatusId = UserStatusConstants.Requested;
		}
		else if (registerDto.RoleName == Role.Student)
		{
			user.StatusId = UserStatusConstants.Active;
		}

		if (registerDto.RoleName == Role.Administrator || registerDto.RoleName == Role.Staff)
			throw new BadRequestException("Only Admin user can perform this action !.");
		
		var result = await _userManager.CreateAsync(user, registerDto.Password);
		
		if (!result.Succeeded)
		{
			var errorMessages = string.Join(", ", result.Errors.Select(e => e.Description));
			throw new BadRequestException(errorMessages);
		}
		
		await _userManager.AddToRoleAsync(user, registerDto.RoleName);

		var token = await _tokenService.CreateToken(user);
		
		return new UserDto
		{
			DisplayName = user.DisplayName,
			Token = token,
			Email = user.Email
		};
	}
	
	private async Task<bool> UserExists(string email)
	{
		return await _userManager.Users.AnyAsync(x => x.Email == email.ToLower());
	}
}