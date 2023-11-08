using HR.DAL.Entities.Identity;

namespace HR.DAL.Entities;

public class UserStatus : BaseEntity
{
	public string StatusName { get; set; }
	public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

	public virtual ICollection<AppUser> Users { get; set; } = new List<AppUser>();
}