namespace HR.DAL.Entities;

public class Commune : BaseEntity
{
	public string CommuneName { get; set; }
	public int DistrictId { get; set; }
	public District District { get; set; }
	public DateTime CreatedDate { get; set; }
}