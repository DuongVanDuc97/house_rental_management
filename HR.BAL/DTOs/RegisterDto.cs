using System.ComponentModel.DataAnnotations;

namespace HR.BAL.DTOs;

public class RegisterDto
{
	public string FacebookUserId { get; set; }
	public string GoogleUserId { get; set; }
	public string DisplayName { get; set; }
	public string GoogleIdToken { get; set; }
	public string ProfileImageLink { get; set; }
	public string Email { get; set; }
	public string Password { get; set; }
	public string PhoneNumber { get; set; }
	public string FacebookUrl { get; set; }
	public string IdentityCardFrontSideImageLink { get; set; }
	public string IdentityCardBackSideImageLink { get; set; } 
}