namespace Neon.Server.RequestEntities.User;

public class UserToGet
{
	public uint Id { get; set; }
	public string Name { get; set; }
	public bool IsAdmin { get; set; }
	public DateTimeOffset CreatedAt { get; set; }
	public DateTimeOffset UpdatedAt { get; set; }
}
