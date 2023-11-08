using AutoMapper;
using HR.BAL.DTOs;
using HR.BAL.DTOs.Responses;
using HR.BAL.Helpers;
using HR.BAL.Interfaces;
using HR.DAL.Entities;
using HR.DAL.Interfaces;
using HR.DAL.Params;
using HR.DAL.Specifications;

namespace HR.BAL.Services;

public class HouseService : IHouseService
{
	private readonly IGenericRepository<House> _houseRepository;
	private readonly IMapper _mapper;

	public HouseService(IGenericRepository<House> houseRepository, IMapper mapper)
	{
		_houseRepository = houseRepository;
		_mapper = mapper;
	}
	
	public async Task<Pagination<HouseDto>> GetAllHouses(HouseSpecParams houseParams)
	{
		var spec = new HousesWithNavigationPropertySpec(houseParams);
		var countSpec = new HouseWithFiltersForCountSpec(houseParams);

		var totalItems = await _houseRepository.CountAsync(countSpec);
		var houses = await _houseRepository.ListAsync(spec);
		
		var data = _mapper.Map<List<HouseDto>>(houses);
		return new Pagination<HouseDto>(houseParams.PageIndex, houseParams.PageSize, totalItems, data);
	}

	public async Task<HouseDetailDto> CreateHouse(CreateHouseDto createHouseDto)
	{
		// var house = _mapper.Map<House>(createHouseDto);
		// house.LandlordId = createHouseDto.LandlordId;
		var house = new House
		{
			HouseName = createHouseDto.HouseName,
			Information = createHouseDto.Information,
			AddressId = createHouseDto.AddressId,
			VillageId = createHouseDto.VillageId,
			LandlordId = createHouseDto.LandlordId,
			CampusId = createHouseDto.CampusId,
			WaterPrice = createHouseDto.WaterPrice,
			PowerPrice = createHouseDto.PowerPrice
		};
			
		var houseEntity = await _houseRepository.AddAsync(house);
		
		return _mapper.Map<HouseDetailDto>(houseEntity);
	}

	public async Task<HouseDetailDto> GetHouse(int id)
	{
		var spec = new HousesWithNavigationPropertySpec(id);
		
		var house = await _houseRepository.GetEntityWithSpec(spec);
		
		return _mapper.Map<HouseDetailDto>(house);
	}

	public async Task<List<HouseDto>> GetHousesByLandlordId(int landlordId)
	{
		var spec = new HousesOfLandlordSpec(landlordId);
		
		var houses = await _houseRepository.ListAsync(spec);

		return _mapper.Map<List<HouseDto>>(houses);
	}

	public async Task DeleteHouse(int id)
	{
		await _houseRepository.DeleteAsync(id);
	}
}

