using AutoMapper;
using HR.BAL.DTOs;
using HR.DAL.Entities.Identity;

namespace HR.BAL.Mapper;

public class MapperProfile : Profile
{
	public MapperProfile()
	{
		CreateMap<RegisterDto, AppUser>().ReverseMap();
		
	}
}

