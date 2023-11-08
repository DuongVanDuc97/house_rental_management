using HR.BAL.DTOs;

namespace HR.BAL.Interfaces;

public interface IAuthService
{
	Task<UserDto> LoginAsync(LoginDto loginDto);
	Task<UserDto> RegisterAsync(RegisterDto registerDto);
}