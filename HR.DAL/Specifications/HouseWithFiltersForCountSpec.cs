using HR.DAL.Entities;
using HR.DAL.Params;

namespace HR.DAL.Specifications;

public class HouseWithFiltersForCountSpec : BaseSpecification<House>
{
	public HouseWithFiltersForCountSpec(HouseSpecParams houseParams) 
		: base(x =>
			(string.IsNullOrEmpty(houseParams.Search) || x.HouseName.ToLower().Contains(houseParams.Search)) &&
			(!houseParams.LandlordId.HasValue || x.LandlordId == houseParams.LandlordId) &&
			(!houseParams.CampusId.HasValue || x.CampusId == houseParams.CampusId) &&
			(!houseParams.VillageId.HasValue || x.VillageId == houseParams.VillageId)
		)
	{
		
	}
}