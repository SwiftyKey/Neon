namespace Neon.Server.RequestEntities.Category;

public class CategoryToGet
{
	public uint Id { get; set; }
	public string Title { get; set; }
	public DateTimeOffset CreatedAt { get; set; }
	public DateTimeOffset UpdatedAt { get; set; }
}
