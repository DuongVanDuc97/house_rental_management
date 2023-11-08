using HR.DAL.Entities;

namespace HR.DAL.Specifications;

public class HousesOfLandlordSpec : BaseSpecification<House>
{
	public HousesOfLandlordSpec(int landlordId) : base(x => x.LandlordId == landlordId)
	{
	}
}