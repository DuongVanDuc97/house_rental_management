using AutoMapper;
using HR.BAL.DTOs;
using HR.BAL.Exceptions;
using HR.BAL.Interfaces;
using HR.DAL.Data;
using HR.DAL.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HR.BAL.Services;

public class AuthService : IAuthService
{
	private readonly UserManager<AppUser> _userManager;
	private readonly ITokenService _tokenService;
	private readonly SignInManager<AppUser> _signInManager;
	private readonly IMapper _mapper;

	public AuthService(
		UserManager<AppUser> userManager, 
		ITokenService tokenService, 
		SignInManager<AppUser> signInManager, 
		IMapper mapper
		)
	{
		_userManager = userManager;
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

		var token = _tokenService.CreateToken(user);
		
		return new UserDto
		{
			Email = user.Email,
			DisplayName = user.DisplayName,
			Token = token
		};
	}

	public async Task<UserDto> RegisterAsync(RegisterDto registerDto)
	{
		var user = _mapper.Map<AppUser>(registerDto);
		user.UserName = user.DisplayName;
		
		var result = await _userManager.CreateAsync(user, registerDto.Password);
		
		if (!result.Succeeded)
		{
			var errorMessages = string.Join(", ", result.Errors.Select(e => e.Description));
			throw new BadRequestException(errorMessages);
		}

		var token = _tokenService.CreateToken(user);
		
		return new UserDto
		{
			DisplayName = user.DisplayName,
			Token = token,
			Email = user.Email
		};
	}
}