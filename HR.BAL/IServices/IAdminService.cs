using HR.BAL.DTOs;
using HR.BAL.DTOs.Responses;

namespace HR.BAL.Interfaces;

public interface IAdminService
{
	Task<StaffDto> CreateStaff(CreateStaffDto createStaffDto);
	Task<StaffDto> UpdateStaff(UpdateStaffDto updateStaffDto);
	Task deleteTask(int staffId);
}