namespace Neon.Server.RequestEntities.User;

public class UserToAuthorize
{
	public required string Login { get; set; }
	public required string Password { get; set; }
}
