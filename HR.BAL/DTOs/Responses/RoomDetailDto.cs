using HR.DAL.Entities;

namespace HR.BAL.DTOs.Responses;

public class RoomDetailDto
{
	public int Id { get; set; }
	public string RoomName { get; set; }
	public decimal Price { get; set; }
	public string Information { get; set; }
	public string RoomStatus { get; set; }
	public string RoomType { get; set; }
	public HouseDto House { get; set; }
}