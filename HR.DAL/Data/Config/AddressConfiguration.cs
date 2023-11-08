using HR.DAL.Entities;
using HR.DAL.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HR.DAL.Data.Config;

public class AddressConfiguration : IEntityTypeConfiguration<Address>
{
	public void Configure(EntityTypeBuilder<Address> builder)
	{
		builder
			.HasMany(a => a.Users)
			.WithOne(a => a.Address)
			.HasForeignKey(a => a.AddressId)
			.IsRequired();
	}
}