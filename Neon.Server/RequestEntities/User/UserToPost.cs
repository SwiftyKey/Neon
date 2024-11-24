namespace Neon.Server.RequestEntities.User;

public class UserToPost
{
	public required string Name { get; set; }
	public required string Password { get; set; }
	public required bool IsAdmin { get; set; }
}
