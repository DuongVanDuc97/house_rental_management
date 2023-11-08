using HR.DAL.Entities;
using HR.DAL.Params;

namespace HR.DAL.Specifications;

public class RoomWithFiltersForCountSpec : BaseSpecification<Room>
{
	public RoomWithFiltersForCountSpec(RoomSpecParams roomParams)
		: base(x =>
			(string.IsNullOrEmpty(roomParams.Search) || x.RoomName.ToLower().Contains(roomParams.Search)) &&
			(!roomParams.HouseId.HasValue || x.HouseId == roomParams.HouseId) &&
			(!roomParams.RoomTypeId.HasValue || x.RoomTypeId == roomParams.RoomTypeId) &&
			(!roomParams.RoomStatusId.HasValue || x.RoomStatusId == roomParams.RoomStatusId)
		)
	{
		
	}
}