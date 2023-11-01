using HR.DAL.Entities.Identity;

namespace HR.BAL.Interfaces;

public interface ITokenService
{
	string CreateToken(AppUser user);
}