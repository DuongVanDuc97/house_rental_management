using HR.DAL.Entities.Identity;

namespace HR.DAL.Entities;

public class Address : BaseEntity
{
	public string Addresses { get; set; }
	public string GoogleMapLocation { get; set; }
	public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
	public DateTime? LastModifiedDate { get; set; }

	public ICollection<Campus> Campuses { get; set; } = new List<Campus>();
	public ICollection<House> Houses { get; set; } = new List<House>();
	public ICollection<AppUser> Users { get; } = new List<AppUser>();
}