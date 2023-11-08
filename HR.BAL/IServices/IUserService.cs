using System.Security.Claims;
using HR.BAL.DTOs;
using HR.BAL.DTOs.Responses;
using HR.DAL.Entities.Identity;

namespace HR.BAL.Interfaces;

public interface IUserService
{
	Task<IEnumerable<UserToReturn>> GetLandlordSignupRequest();
	Task<IEnumerable<UserToReturn>> GetActiveLandlords();
	Task<IEnumerable<UserToReturn>> GetInactiveLandlords();
	Task<UserToReturn> UpdateUserStatus(int userId, int statusId, int staffId);
}