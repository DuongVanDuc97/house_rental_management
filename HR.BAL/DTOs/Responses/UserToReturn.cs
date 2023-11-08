namespace HR.BAL.DTOs.Responses;

public class UserToReturn
{
	public int Id { get; set; }
	public string DisplayName { get; set; }
	public string Email { get; set; }
	public string PhoneNumber { get; set; }
	public string Status { get; set; }
}