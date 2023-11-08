using HR.BAL.DTOs;
using HR.BAL.DTOs.Responses;
using HR.BAL.Helpers;
using HR.DAL.Params;

namespace HR.BAL.Interfaces;

public interface IRoomService
{
	Task<RoomDto> CreateRoom(CreateRoomDto createRoomDto);
	Task<RoomDetailDto> GetRoomById(int roomId);
	Task<RoomDto> UpdateRoom(int roomId, UpdateRoomDto updateRoomDto);
	Task DeleteRoom(int roomId);
	Task<Pagination<RoomDto>> GetAllRooms(RoomSpecParams roomParams);
}