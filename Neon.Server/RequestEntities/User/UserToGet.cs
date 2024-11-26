namespace Neon.Server.RequestEntities.User;

public class UserToGet
{
	public uint Id { get; set; }
	public string Name { get; set; }
	public bool IsAdmin { get; set; }
	public ICollection<Domain.Entities.Order> Orders { get; set; } = [];
	public ICollection<Domain.Entities.History> History { get; set; } = [];
	public DateTimeOffset CreatedAt { get; set; }
	public DateTimeOffset UpdatedAt { get; set; }
}
