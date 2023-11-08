using HR.BAL.DTOs;
using HR.BAL.DTOs.Responses;
using HR.BAL.Helpers;
using HR.DAL.Entities;
using HR.DAL.Params;
using HR.DAL.Specifications;

namespace HR.BAL.Interfaces;

public interface IHouseService
{
	Task<Pagination<HouseDto>> GetAllHouses(HouseSpecParams houseParams);
	Task<HouseDetailDto> CreateHouse(CreateHouseDto houseDto);
	Task<HouseDetailDto> GetHouse(int id);
	Task<List<HouseDto>> GetHousesByLandlordId(int id);
	Task DeleteHouse(int id);
}