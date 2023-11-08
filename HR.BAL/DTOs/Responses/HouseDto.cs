using HR.DAL.Entities;
using HR.DAL.Entities.Identity;

namespace HR.BAL.DTOs.Responses;

public class HouseDto
{
	public int Id { get; set; }
	public string HouseName { get; set; }
	public string Information { get; set; }
	public int AddressId { get; set; }
	public int? VillageId { get; set; }
	public int LandlordId { get; set; }
	public int? CampusId { get; set; }
	public decimal PowerPrice { get; set; }
	public decimal WaterPrice { get; set; }
}