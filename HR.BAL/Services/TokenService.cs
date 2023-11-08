using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using HR.BAL.Interfaces;
using HR.DAL.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace HR.BAL.Services;

public class TokenService : ITokenService
{
	private readonly IConfiguration _config;
	private readonly UserManager<AppUser> _userManager;
	private readonly SymmetricSecurityKey _key;

	public TokenService(IConfiguration config, UserManager<AppUser> userManager)
	{
		_config = config;
		_userManager = userManager;
		_key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Token:Key"]));
	}
	public async Task<string> CreateToken(AppUser user)
	{
		var claims = new List<Claim>
		{
			new Claim(ClaimTypes.Email, user.Email),
			new Claim(ClaimTypes.GivenName, user.DisplayName),
		};
		
		var roles = await _userManager.GetRolesAsync(user);
		claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

		var credentials = new SigningCredentials(_key, SecurityAlgorithms.HmacSha256Signature);

		var tokenDescriptor = new SecurityTokenDescriptor
		{
			Subject = new ClaimsIdentity(claims),
			Expires = DateTime.Now.AddDays(7),
			SigningCredentials = credentials,
		};

		var tokenHandler = new JwtSecurityTokenHandler();
		var token = tokenHandler.CreateToken(tokenDescriptor);
		return tokenHandler.WriteToken(token);
	}
}