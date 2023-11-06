namespace HR.DAL.Entities;

public class Campus : BaseEntity
{
	public string CampusName { get; set; }
	public int AddressId { get; set; }
	public Address Address { get; set; }
	public DateTime CreatedDate { get; set; }
	public ICollection<House> Houses { get; set; } = new List<House>();
}