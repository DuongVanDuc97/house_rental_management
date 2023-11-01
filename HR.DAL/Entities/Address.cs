namespace HR.DAL.Entities;

public class Address : BaseEntity
{
	public string Addresses { get; set; }
	public string GoogleMapLocation { get; set; }
	public DateTime CreatedDate { get; set; }
	public DateTime? LastModifiedDate { get; set; }
}