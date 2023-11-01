using HR.BAL.DTOs;
using HR.BAL.Interfaces;

namespace HR.BAL.Services;

public class UserService : IUserService
{
	public UserService()
	{
		
	}
	public Task<List<UserDto>> GetUsers()
	{
		throw new NotImplementedException();
	}

	public Task<UserDto> GetUserById(int userId)
	{
		throw new NotImplementedException();
	}
}