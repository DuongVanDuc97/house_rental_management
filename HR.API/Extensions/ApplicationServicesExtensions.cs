using System.Text;
using HR.BAL.Interfaces;
using HR.BAL.Services;
using HR.DAL.Data;
using HR.DAL.Entities.Identity;
using HR.DAL.Interfaces;
using HR.DAL.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace HR.API.Extensions;

public static class ApplicationServicesExtensions
{
	public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
	{
		services.AddDbContext<ApplicationDbContext>(opt =>
		{
			opt.UseNpgsql(config.GetConnectionString("DefaultConnection"));
		});
		services.AddIdentityCore<AppUser>(opt =>
			{

			})
			.AddRoles<AppRole>()
			.AddRoleManager<RoleManager<AppRole>>()
			.AddEntityFrameworkStores<ApplicationDbContext>()
			.AddSignInManager<SignInManager<AppUser>>();

		services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
			.AddJwtBearer(options =>
			{
				options.TokenValidationParameters = new TokenValidationParameters
				{
					ValidateIssuerSigningKey = true,
					IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Token:Key"])),
					// ValidIssuer = config["Token:Issuer"],
					ValidateIssuer = false,
					ValidateAudience = false
				};
			});
		services.AddAuthorization();
		services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
		services.AddScoped<ITokenService, TokenService>();
		services.AddScoped<IAuthService, AuthService>();
		services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

		return services;
	}
}