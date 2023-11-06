namespace HR.DAL.Entities;

public class District : BaseEntity
{
	public string DistrictName { get; set; }
	public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

	public ICollection<Commune> Communes { get; set; } = new List<Commune>();
	
}