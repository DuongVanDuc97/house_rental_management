namespace HR.DAL.Entities;

public class HouseImage : BaseEntity
{
	public string ImageLink { get; set; }
	public int HouseId { get; set; }
	public bool Deleted { get; set; }
	public DateTime CreatedDate { get; set; }
	public DateTime? LastModifiedDate { get; set; }
	public string CreatedBy { get; set; }
	public string LastModifiedBy { get; set; }
	
	public House House { get; set; }
}