using HR.DAL.Entities;
using HR.DAL.Params;

namespace HR.DAL.Specifications;

public class RoomWithNavigationPropertySpec : BaseSpecification<Room>
{
	public RoomWithNavigationPropertySpec(RoomSpecParams roomParams)
		: base(x => 
			(string.IsNullOrEmpty(roomParams.Search) || x.RoomName.ToLower().Contains(roomParams.Search)) &&
			(!roomParams.HouseId.HasValue || x.HouseId == roomParams.HouseId) &&
			(!roomParams.RoomTypeId.HasValue || x.RoomTypeId == roomParams.RoomTypeId) &&
			(!roomParams.RoomStatusId.HasValue || x.RoomStatusId == roomParams.RoomStatusId) 
			)
	{
		ApplyPaging(roomParams.PageSize * (roomParams.PageIndex - 1), roomParams.PageSize);

		if (!string.IsNullOrEmpty(roomParams.Sort))
		{
			switch (roomParams.Sort)
			{
				case "priceAsc":
					AddOrderBy(x => x.Price);
					break;
				case "priceDesc":
					AddOrderByDescending(x => x.Price);
					break;
				default:
					AddOrderBy(x => x.RoomName);
					break;
			}
		}
	}
	
	public RoomWithNavigationPropertySpec(int id) : base(x => x.Id == id)
	{
		AddInclude(x => x.House);
		AddInclude(x => x.RoomStatus);
		AddInclude(x => x.RoomType);
	}
}