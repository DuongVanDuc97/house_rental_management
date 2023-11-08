using HR.DAL.Entities.Identity;

namespace HR.BAL.Interfaces;

public interface ITokenService
{
	Task<string> CreateToken(AppUser user);
}