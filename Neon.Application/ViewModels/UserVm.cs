namespace Neon.Application.ViewModels;

public class UserVm: BaseVm
{
	public string? Name { get; set; }
	public string? Password { get; set; }
	public bool IsAdmin { get; set; }
}
