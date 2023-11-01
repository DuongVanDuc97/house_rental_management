namespace HR.DAL.Entities;

public class District : BaseEntity
{
	public string DistrictName { get; set; }
	public int? CampusId { get; set; }
	public Campus Campus { get; set; }

	public DateTime CreatedDate { get; set; }
}