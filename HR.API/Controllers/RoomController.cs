using HR.API.Controllers.Base;
using HR.API.Reponses;
using HR.BAL.DTOs;
using HR.BAL.DTOs.Responses;
using HR.BAL.Helpers;
using HR.BAL.Interfaces;
using HR.DAL.Params;
using Microsoft.AspNetCore.Mvc;

namespace HR.API.Controllers;

public class RoomController : BaseApiController
{
	private readonly IRoomService _roomService;

	public RoomController(IRoomService roomService)
	{
		_roomService = roomService;
	}
	
	[HttpPost]
	public async Task<ActionResult<RoomDto>> CreateRoom(CreateRoomDto createRoomDto)
	{
		var room = await _roomService.CreateRoom(createRoomDto);
		return Ok(ApiResult<RoomDto>.Success(room));
	}
	
	[HttpGet("{roomId}")]
	public async Task<ActionResult<RoomDetailDto>> GetRoomById(int roomId)
	{
		var room = await _roomService.GetRoomById(roomId);

		return Ok(ApiResult<RoomDetailDto>.Success(room));
	}
	
	[HttpGet]
	public async Task<ActionResult<Pagination<RoomDto>>> GetRooms([FromQuery] RoomSpecParams roomParams)
	{
		var room = await _roomService.GetAllRooms(roomParams);
		return Ok(ApiResult<Pagination<RoomDto>>.Success(room));
	}
	
	[HttpPut("{roomId}")]
	public async Task<ActionResult<RoomDto>> UpdateRoom(int roomId, UpdateRoomDto updateRoomDto)
	{
		var updatedRoomDto = await _roomService.UpdateRoom(roomId, updateRoomDto);

		return Ok(updatedRoomDto);
	}
	
	[HttpDelete("{roomId}")]
	public async Task<IActionResult> DeleteRoom(int roomId)
	{
		await _roomService.DeleteRoom(roomId);
		return NoContent(); // Return 204 for successful deletion
	}
}