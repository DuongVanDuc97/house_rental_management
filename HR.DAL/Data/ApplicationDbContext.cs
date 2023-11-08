using System.Reflection;
using HR.DAL.Constants;
using HR.DAL.Entities;
using HR.DAL.Entities.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UserStatus = HR.DAL.Entities.UserStatus;

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
	public DbSet<Room> Rooms { get; set; }
	public DbSet<RoomType> RoomTypes { get; set; }
	public DbSet<RoomStatus> RoomStatus { get; set; }
	public DbSet<UserStatus> UserStatus { get; set; }

	protected override void OnModelCreating(ModelBuilder builder)
	{
		base.OnModelCreating(builder);

		// builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

		builder.Entity<AppUser>().Navigation(e => e.Status).AutoInclude();

		builder.Entity<AppRole>().HasData(
			new AppRole { Id = 1, Name = Role.Administrator, NormalizedName = Role.Administrator.ToUpper(), ConcurrencyStamp = Guid.NewGuid().ToString()},
			new AppRole { Id = 2, Name = Role.Landlord, NormalizedName = Role.Landlord.ToUpper(), ConcurrencyStamp = Guid.NewGuid().ToString()},
			new AppRole { Id = 3, Name = Role.Student, NormalizedName = Role.Student.ToUpper(), ConcurrencyStamp = Guid.NewGuid().ToString()},
			new AppRole { Id = 4, Name = Role.Staff, NormalizedName = Role.Staff.ToUpper(), ConcurrencyStamp = Guid.NewGuid().ToString()}
			);

		builder.Entity<RoomType>().HasData(
			new RoomType { Id = (int)RoomTypeEnum.Private, RoomTypeName = RoomTypeEnum.Private.ToString()},
			new RoomType { Id = (int)RoomTypeEnum.Open, RoomTypeName = RoomTypeEnum.Open.ToString()}
		);

		builder.Entity<RoomStatus>().HasData(
			new RoomStatus {Id = (int)RoomStatusEnum.Available, StatusName = RoomStatusEnum.Available.ToString()},
			new RoomStatus {Id = (int)RoomStatusEnum.Occupied, StatusName = RoomStatusEnum.Occupied.ToString()},
			new RoomStatus {Id = (int)RoomStatusEnum.Unavailable, StatusName = RoomStatusEnum.Unavailable.ToString()}
		);

		builder.Entity<UserStatus>().HasData(
			new UserStatus { Id = UserStatusConstants.Inactive, StatusName = "Inactive" },
			new UserStatus { Id = UserStatusConstants.Active, StatusName = "Active" },
			new UserStatus { Id = UserStatusConstants.Requested, StatusName = "Requested" },
			new UserStatus { Id = UserStatusConstants.Rejected, StatusName = "Rejected" }
		);
	}
}