namespace HR.DAL.Entities;

public class Village : BaseEntity
{
	public string VillageName { get; set; }
	public int CommuneId { get; set; }
	public Commune Commune { get; set; }
	public DateTime CreatedDate { get; set; }
}