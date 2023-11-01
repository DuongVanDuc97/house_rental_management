using HR.DAL.Entities.Identity;

namespace HR.DAL.Entities;

public class Rate : BaseEntity
{
	
	public int? Star { get; set; }
	public string Comment { get; set; }
	public string LandlordReply { get; set; }
	public int HouseId { get; set; }
	public int StudentId { get; set; }
	public bool Deleted { get; set; }
	public DateTime CreatedDate { get; set; }
	public DateTime? LastModifiedDate { get; set; }
	public string CreatedBy { get; set; }
	public string LastModifiedBy { get; set; }
	
	public House House { get; set; }
	public AppUser Student { get; set; }
}