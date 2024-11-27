namespace Neon.Server.RequestEntities.Order;

public class OrderToGet
{
	public int Id { get; set; }
	public string Title { get; set; }
	public int UserId { get; set; }
	public ICollection<Domain.Entities.OrderComposition> Compositions { get; set; } = [];
	public DateTimeOffset CreatedAt { get; set; }
	public DateTimeOffset UpdatedAt { get; set; }
}
