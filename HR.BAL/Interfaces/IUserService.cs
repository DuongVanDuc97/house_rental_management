using HR.BAL.DTOs;
using HR.DAL.Entities.Identity;

namespace HR.BAL.Interfaces;

public interface IUserService
{
	Task<List<UserDto>> GetUsers();
	Task<UserDto> GetUserById(int userId);
}