namespace HR.DAL.Entities;

public class RoomStatus : BaseEntity
{ 
	public string StatusName { get; set; }
	public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

	public ICollection<Room> Rooms { get; set; } = new List<Room>();
}