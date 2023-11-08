namespace HR.BAL.DTOs;

public class CreateRoomDto
{
	public string RoomName { get; set; }
	public decimal Price { get; set; }
	public string Information { get; set; }
	public int RoomStatusId { get; set; }
	public int RoomTypeId { get; set; }
	public int HouseId { get; set; }
}