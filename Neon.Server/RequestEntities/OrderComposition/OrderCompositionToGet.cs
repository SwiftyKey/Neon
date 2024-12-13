namespace Neon.Server.RequestEntities.OrderComposition;

public class OrderCompositionToGet
{
	public int Id { get; set; }
	public Domain.Entities.Order Order { get; set; }
	public Domain.Entities.Product Product { get; set; }
	public int Count { get; set; }
	public DateTimeOffset CreatedAt { get; set; }
	public DateTimeOffset UpdatedAt { get; set; }
}
