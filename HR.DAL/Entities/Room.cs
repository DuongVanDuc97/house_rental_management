namespace HR.DAL.Entities;

public class Room : BaseEntity
{
	public string RoomName { get; set; }
	public decimal Price { get; set; }
	public string Information { get; set; }
	public int RoomStatusId { get; set; }
	public int RoomTypeId { get; set; }
	public int HouseId { get; set; }
	public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
	public DateTime? LastModifiedDate { get; set; }
	public string? CreatedBy { get; set; }
	public string? LastModifiedBy { get; set; }
	
	public House House { get; set; }
	public RoomType RoomType { get; set; }
	public RoomStatus RoomStatus { get; set; }
}