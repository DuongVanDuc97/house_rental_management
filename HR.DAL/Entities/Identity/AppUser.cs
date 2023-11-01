using Microsoft.AspNetCore.Identity;

namespace HR.DAL.Entities.Identity;

public class AppUser : IdentityUser<int>
{
	public string FacebookUserId { get; set; }
	public string GoogleUserId { get; set; }
	public string DisplayName { get; set; }
	public int StatusId { get; set; }
	public string ProfileImageLink { get; set; }
	public string PhoneNumber { get; set; }
	public string FacebookUrl { get; set; }
	public string IdentityCardFrontSideImageLink { get; set; }
	public string IdentityCardBackSideImageLink { get; set; }
	
}