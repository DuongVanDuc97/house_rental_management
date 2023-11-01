using HR.DAL.Entities.Identity;

namespace HR.DAL.Entities;

public class House : BaseEntity
{
	public string HouseName { get; set; }
	public string Information { get; set; }
	public int AddressId { get; set; }
	public int? VillageId { get; set; }
	public int LandlordId { get; set; }
	public int? CampusId { get; set; }
	public decimal PowerPrice { get; set; }
	public decimal WaterPrice { get; set; }
	public DateTime CreatedDate { get; set; }
	public DateTime? LastModifiedDate { get; set; }
	public string CreatedBy { get; set; }
	public string LastModifiedBy { get; set; }

	public Address Address { get; set; }
	public Campus Campus { get; set; }
	public AppUser Landlord { get; set; }
	public Village Village { get; set; }
}