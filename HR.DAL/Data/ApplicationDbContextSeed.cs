using System.Reflection;
using System.Text.Json;
using HR.DAL.Constants;
using HR.DAL.Entities;
using HR.DAL.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HR.DAL.Data;

public class ApplicationDbContextSeed
{
	public static async Task SeedUser(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
	{
		if (await userManager.Users.AnyAsync()) return;

		// Create Admin User
		var adminUser = new AppUser
		{
			DisplayName = "Admin",
			UserName = "admin@example.com",
			Email = "admin@example.com",
			PhoneNumber = "123456789",
			RoleId = (await roleManager.FindByNameAsync(Role.Administrator))?.Id ?? 1,
			StatusId = UserStatusConstants.Active,
			CreatedDate = DateTime.UtcNow
		};

		await userManager.CreateAsync(adminUser, "Admin@123"); // Change the password as needed
		await userManager.AddToRoleAsync(adminUser, Role.Administrator);

		// Create Landlord Users
		for (int i = 1; i <= 4; i++)
		{
			var landlordUser = new AppUser
			{
				DisplayName = $"Landlord{i}",
				UserName = $"landlord{i}@example.com",
				Email = $"landlord{i}@example.com",
				PhoneNumber = "123456789",
				RoleId = (await roleManager.FindByNameAsync(Role.Landlord))?.Id ?? 0,
				StatusId = UserStatusConstants.Active,
				CreatedDate = DateTime.UtcNow
			};

			await userManager.CreateAsync(landlordUser, "Landlord@123");
			await userManager.AddToRoleAsync(landlordUser, Role.Landlord);
		}
	}

		
	public static async Task SeedAsync(ApplicationDbContext context)
	{
		var path = "/Users/therealnig/Documents/dotNET/House_Rental_Management/HR.DAL";

		if (!context.Districts.Any())
		{
			var districtsJson = File.ReadAllText(path + @"/Data/SeedData/districts.json");
			var districts = JsonSerializer.Deserialize<List<District>>(districtsJson);
			context.Districts.AddRange(districts);
			context.SaveChanges();
		}
		
		if (!context.Communes.Any())
		{
			var communesJson = File.ReadAllText(path + @"/Data/SeedData/communes.json");
			var communes = JsonSerializer.Deserialize<List<Commune>>(communesJson);
			context.Communes.AddRange(communes);
			context.SaveChanges();
		}
		
		if (!context.Villages.Any())
		{
			var villagesJson = File.ReadAllText(path + @"/Data/SeedData/villages.json");
			var villages = JsonSerializer.Deserialize<List<Village>>(villagesJson);
			context.Villages.AddRange(villages);
			context.SaveChanges();
		}
		
		if (!context.Addresses.Any())
		{
			var addressesJson = File.ReadAllText(path + @"/Data/SeedData/addresses.json");
			var addresses = JsonSerializer.Deserialize<List<Address>>(addressesJson);
			context.Addresses.AddRange(addresses);
			context.SaveChanges();
		}
		
		if (!context.Campuses.Any())
		{
			var campusesJson = File.ReadAllText(path + @"/Data/SeedData/campuses.json");
			var campuses = JsonSerializer.Deserialize<List<Campus>>(campusesJson);
			context.Campuses.AddRange(campuses);
			context.SaveChanges();
		}
		
		// if (!context.Houses.Any())
		// {
		// 	var housesJson = File.ReadAllText(path + @"/Data/SeedData/houses.json");
		// 	var houses = JsonSerializer.Deserialize<List<House>>(housesJson);
		// 	context.Houses.AddRange(houses);
		// 	context.SaveChanges();
		// }
	}
	
}