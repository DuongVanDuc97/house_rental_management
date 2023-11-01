namespace HR.DAL.Entities;

public class Room : BaseEntity
{
	public string RoomName { get; set; }
	public decimal Price { get; set; }
	public string Information { get; set; }
	public double? Area { get; set; }
	public int? MaxAmountOfPeople { get; set; }
	public int? CurrentAmountOfPeople { get; set; }
	public int? BuildingNumber { get; set; }
	public int? FloorNumber { get; set; }
	public int StatusId { get; set; }
	public int RoomTypeId { get; set; }
	public int HouseId { get; set; }
	public DateTime CreatedDate { get; set; }
	public DateTime? LastModifiedDate { get; set; }
	public string CreatedBy { get; set; }
	public string LastModifiedBy { get; set; }
	
	public House House { get; set; }
	public RoomType RoomType { get; set; }
	public Status Status { get; set; }
}