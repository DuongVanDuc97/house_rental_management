using HR.DAL.Entities;
using HR.DAL.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HR.DAL.Data.Config;

public class UserConfiguration : IEntityTypeConfiguration<AppUser>
{
	public void Configure(EntityTypeBuilder<AppUser> builder)
	{
		// builder
		// 	.HasOne(a => a.Address)
		// 	.WithOne()
		// 	.HasForeignKey<Address>(a => a.Id)
		// 	.OnDelete(DeleteBehavior.Cascade);
	}
}