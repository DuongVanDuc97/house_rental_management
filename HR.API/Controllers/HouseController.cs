using HR.API.Controllers.Base;
using HR.API.Extensions;
using HR.API.Reponses;
using HR.BAL.DTOs;
using HR.BAL.DTOs.Responses;
using HR.BAL.Helpers;
using HR.BAL.Interfaces;
using HR.DAL.Constants;
using HR.DAL.Data;
using HR.DAL.Entities;
using HR.DAL.Entities.Identity;
using HR.DAL.Interfaces;
using HR.DAL.Params;
using HR.DAL.Specifications;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HR.API.Controllers;

public class HouseController : BaseApiController
{
	private readonly IHouseService _houseService;
	private readonly UserManager<AppUser> _userManager;

	public HouseController(IHouseService houseService, UserManager<AppUser> userManager)
	{
		_houseService = houseService;
		_userManager = userManager;
	}

	[HttpGet]
	public async Task<ActionResult<Pagination<HouseDto>>> GetAllHouses([FromQuery] HouseSpecParams houseParams)
	{
		var houses = await _houseService.GetAllHouses(houseParams);
		
		return Ok(ApiResult<Pagination<HouseDto>>.Success(houses));
	}
	
	[Authorize(Roles = Role.Landlord)]
	[HttpPost]
	public async Task<ActionResult<HouseDetailDto>> CreateHouse(CreateHouseDto createHouseDto)
	{
		var landlord = await _userManager.FindByEmailFromClaimsPrincipal(User);

		if (landlord.StatusId != UserStatusConstants.Active) return Unauthorized("Unauthorized landlord");
		
		createHouseDto.LandlordId = landlord.Id;
		
		var house = await _houseService.CreateHouse(createHouseDto);
		
		return Ok(ApiResult<HouseDetailDto>.Success(house));
	}

	[HttpGet("{id}")]
	public async Task<ActionResult<HouseDetailDto>> GetHouseById(int id)
	{
		var house = await _houseService.GetHouse(id);
		return Ok(ApiResult<HouseDetailDto>.Success(house));
	}

	[HttpDelete("{id}")]
	public async Task<IActionResult> DeleteHouse(int id)
	{
		await _houseService.DeleteHouse(id);
		return Ok();
	}

	[HttpGet("housesByLandlord/{landlordId}")]
	public async Task<ActionResult<List<HouseDto>>> GetHousesByLandlordId(int landlordId)
	{
		var houses = await _houseService.GetHousesByLandlordId(landlordId);
		return Ok(ApiResult<List<HouseDto>>.Success(houses));
	}
	
	
	// [HttpGet("availableHouse")]
	// public ActionResult<IEnumerable<>>
}