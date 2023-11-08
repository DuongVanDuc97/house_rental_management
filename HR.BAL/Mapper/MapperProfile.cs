using AutoMapper;
using HR.BAL.DTOs;
using HR.BAL.DTOs.Responses;
using HR.DAL.Entities;
using HR.DAL.Entities.Identity;

namespace HR.BAL.Mapper;

public class MapperProfile : Profile
{
	public MapperProfile()
	{
		CreateMap<RegisterDto, AppUser>().ReverseMap();
		CreateMap<House, HouseDto>().ReverseMap();
		CreateMap<House, HouseDetailDto>();
		CreateMap<CreateHouseDto, House>();
		CreateMap<AppUser, UserToReturn>()
			.ForMember(d => d.Status, o => o.MapFrom(s => s.Status.StatusName));
		CreateMap<CreateStaffDto, AppUser>().ReverseMap();
		CreateMap<AppUser, StaffDto>();
		CreateMap<CreateRoomDto, Room>();
		CreateMap<Room, RoomDto>();
		CreateMap<Room, RoomDetailDto>()
			.ForMember(d => d.RoomStatus, o => o.MapFrom(s => s.RoomStatus.StatusName))
			.ForMember(d => d.RoomType, o => o.MapFrom(s => s.RoomType.RoomTypeName));
		CreateMap<UpdateRoomDto, Room>();
		CreateMap<Village, VillageDto>();
		CreateMap<Campus, CampusDto>();
		CreateMap<Address, AddressDto>();
	}
}

