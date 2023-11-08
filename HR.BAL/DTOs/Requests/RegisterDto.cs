using System.ComponentModel.DataAnnotations;

namespace HR.BAL.DTOs;

public class RegisterDto
{
	public string DisplayName { get; set; }
	public string? ProfileImageLink { get; set; }
	public string Email { get; set; }
	public string Password { get; set; }
	public int? AddressId { get; set; }
	public string PhoneNumber { get; set; }
	public string? FacebookUrl { get; set; }
	public string RoleName { get; set; }
}