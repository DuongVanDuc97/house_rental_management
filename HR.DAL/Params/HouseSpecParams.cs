namespace HR.DAL.Params;

public class HouseSpecParams : BaseSpecParams
{
	public int? LandlordId { get; set; }
	public int? CampusId { get; set; }
	public int? VillageId { get; set; }
}