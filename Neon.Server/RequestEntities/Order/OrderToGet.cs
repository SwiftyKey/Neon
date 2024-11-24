namespace Neon.Server.RequestEntities.Order;

public class OrderToGet
{
	public uint Id { get; set; }
	public string Title { get; set; }
	public uint UserId { get; set; }
	public DateTimeOffset CreatedAt { get; set; }
	public DateTimeOffset UpdatedAt { get; set; }
}
