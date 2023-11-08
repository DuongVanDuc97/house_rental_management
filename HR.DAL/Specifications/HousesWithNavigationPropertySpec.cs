using HR.DAL.Entities;
using HR.DAL.Params;

namespace HR.DAL.Specifications;

public class HousesWithNavigationPropertySpec : BaseSpecification<House>
{
	public HousesWithNavigationPropertySpec(HouseSpecParams houseParams) 
		: base(x =>
			(string.IsNullOrEmpty(houseParams.Search) || x.HouseName.ToLower().Contains(houseParams.Search)) &&
			(!houseParams.LandlordId.HasValue || x.LandlordId == houseParams.LandlordId) &&
			(!houseParams.CampusId.HasValue || x.CampusId == houseParams.CampusId) &&
			(!houseParams.VillageId.HasValue || x.VillageId == houseParams.VillageId)
			)
	{
		ApplyPaging(houseParams.PageSize * (houseParams.PageIndex - 1), houseParams.PageSize);

		if (!string.IsNullOrEmpty(houseParams.Sort))
		{
			switch (houseParams.Sort)
			{
				case "powerPriceAsc":
					AddOrderBy(x => x.PowerPrice);
					break;
				case "powerPriceDesc":
					AddOrderByDescending(x => x.PowerPrice);
					break;
				case "waterPriceAsc":
					AddOrderBy(x => x.WaterPrice);
					break;
				case "waterPriceDesc":
					AddOrderByDescending(x => x.WaterPrice);
					break;
				default:
					AddOrderBy(x => x.HouseName);
					break;
			}
		}
	}

	public HousesWithNavigationPropertySpec(int id) : base(x => x.Id == id)
	{
		AddInclude(x => x.Address);
		AddInclude(x => x.Landlord);
		AddInclude(x => x.Campus);
		AddInclude(x => x.Village);
	}
}