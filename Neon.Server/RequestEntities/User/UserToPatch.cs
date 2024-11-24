namespace Neon.Server.RequestEntities.User;

public class UserToPatch
{
	public string? Name { get; set; }
	public string? Password { get; set; }
	public bool? IsAdmin { get; set; }
}
