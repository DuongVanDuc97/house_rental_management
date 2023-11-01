using System.Reflection;
using HR.DAL.Entities;
using HR.DAL.Entities.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HR.DAL.Data;

public class ApplicationDbContext : IdentityDbContext<AppUser, AppRole, int>
{
	public ApplicationDbContext(DbContextOptions options) : base(options)
	{
	}

	public DbSet<Address> Addresses { get; set; }
	public DbSet<Campus> Campuses { get; set; }
	public DbSet<Commune> Communes { get; set; }
	public DbSet<District> Districts { get; set; }
	public DbSet<Village> Villages { get; set; }
	public DbSet<House> Houses { get; set; }
	public DbSet<HouseImage> HouseImages { get; set; }
	public DbSet<Rate> Rates { get; set; }
	public DbSet<RoomType> RoomTypes { get; set; }
	public DbSet<Status> Statuses { get; set; }

	protected override void OnModelCreating(ModelBuilder builder)
	{
		base.OnModelCreating(builder);

		// builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

		// builder.Entity<AppUser>()
		// 	.HasOne(a => a.Address)
		// 	.WithOne()
		// 	.HasForeignKey<Address>(a => a.Id)
		// 	.OnDelete(DeleteBehavior.Cascade);

		builder.Entity<AppRole>()
			.HasData(
				new AppRole { Id = 1, Name = "Student", NormalizedName = "STUDENT", ConcurrencyStamp = Guid.NewGuid().ToString()},
				new AppRole { Id = 2, Name = "Landlord", NormalizedName = "LANDLORD", ConcurrencyStamp = Guid.NewGuid().ToString()}
				);
	}
}