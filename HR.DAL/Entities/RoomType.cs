namespace HR.DAL.Entities;

public class RoomType : BaseEntity
{
	public string RoomTypeName { get; set; }
	public DateTime CreatedDate { get; set; }
	public ICollection<Room> Rooms { get; set; } = new List<Room>();
}