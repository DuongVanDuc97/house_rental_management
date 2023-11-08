namespace HR.BAL.DTOs.Responses;

public class RoomDto
{
	public int Id { get; set; }
	public string RoomName { get; set; }
	public decimal Price { get; set; }
	public string Information { get; set; }
	public int RoomStatusId { get; set; }
	public int RoomTypeId { get; set; }
	public int HouseId { get; set; }
}