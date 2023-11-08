using AutoMapper;
using HR.BAL.DTOs;
using HR.BAL.DTOs.Responses;
using HR.BAL.Exceptions;
using HR.BAL.Helpers;
using HR.BAL.Interfaces;
using HR.DAL.Entities;
using HR.DAL.Interfaces;
using HR.DAL.Params;
using HR.DAL.Specifications;

namespace HR.BAL.Services;

public class RoomService : IRoomService
{
	private readonly IGenericRepository<Room> _roomRepository;
	private readonly IMapper _mapper;

	public RoomService(IGenericRepository<Room> roomRepository, IMapper mapper)
	{
		_roomRepository = roomRepository;
		_mapper = mapper;
	}
	
	public async Task<RoomDto> CreateRoom(CreateRoomDto createRoomDto)
	{
		var roomEntity = _mapper.Map<Room>(createRoomDto);
		
		var addedRoom = await _roomRepository.AddAsync(roomEntity);
		
		var roomDto = _mapper.Map<RoomDto>(addedRoom);

		return roomDto;
	}

	public async Task<RoomDetailDto> GetRoomById(int roomId)
	{
		// var roomEntity = await _roomRepository.GetByIdAsync(roomId);

		var spec = new RoomWithNavigationPropertySpec(roomId);

		var room = await _roomRepository.GetEntityWithSpec(spec);
		
		if (room == null) throw new NotFoundException("Room Not Found");
		
		var roomDto = _mapper.Map<RoomDetailDto>(room);

		return roomDto;

	}

	public async Task<Pagination<RoomDto>> GetAllRooms(RoomSpecParams roomParams)
	{
		var spec = new RoomWithNavigationPropertySpec(roomParams);
		var countSpec = new RoomWithFiltersForCountSpec(roomParams);
		
		var rooms = await _roomRepository.ListAsync(spec);
		var totalItems = await _roomRepository.CountAsync(countSpec);
		
		var data = _mapper.Map<List<RoomDto>>(rooms);
		return new Pagination<RoomDto>(roomParams.PageIndex, roomParams.PageSize, totalItems, data);
	}

	public async Task<RoomDto> UpdateRoom(int roomId, UpdateRoomDto updateRoomDto)
	{
		var existingRoom = await _roomRepository.GetByIdAsync(roomId);

		if (existingRoom == null) throw new NotFoundException("Room Not Found");
		
		_mapper.Map(updateRoomDto, existingRoom);
		
		await _roomRepository.UpdateAsync(existingRoom);
		
		var updatedRoomDto = _mapper.Map<RoomDto>(existingRoom);

		return updatedRoomDto;
	}

	public async Task DeleteRoom(int roomId)
	{
		var roomExists = await _roomRepository.Exists(roomId);

		if (!roomExists) throw new NotFoundException("Room Not Found");
			
		await _roomRepository.DeleteAsync(roomId);	
		
	}
}