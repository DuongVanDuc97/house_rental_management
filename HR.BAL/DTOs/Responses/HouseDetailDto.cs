namespace HR.BAL.DTOs.Responses;

public class HouseDetailDto
{
	public int Id { get; set; }
	public string HouseName { get; set; }
	public string Information { get; set; }
	public AddressDto Address { get; set; }
	public VillageDto Village { get; set; }
	public UserToReturn Landlord { get; set; }
	public CampusDto Campus { get; set; }
	public decimal PowerPrice { get; set; }
	public decimal WaterPrice { get; set; }
}