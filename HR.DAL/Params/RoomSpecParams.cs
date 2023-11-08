namespace HR.DAL.Params;

public class RoomSpecParams : BaseSpecParams
{
	public int? RoomStatusId { get; set; }
	public int? RoomTypeId { get; set; }
	public int? HouseId { get; set; }
	public decimal? Price { get; set; }

}