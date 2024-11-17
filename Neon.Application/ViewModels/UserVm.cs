namespace Neon.Application.ViewModels;

public class UserVm: BaseVm
{
	public required string Name { get; set; }
	public required string Email { get; set; }
	public string? PhoneNumber { get; set; }
	public required string Password { get; set; }
}
