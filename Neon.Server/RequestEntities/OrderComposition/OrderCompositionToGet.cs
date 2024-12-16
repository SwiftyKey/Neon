using Neon.Server.RequestEntities.Order;
using Neon.Server.RequestEntities.Product;

namespace Neon.Server.RequestEntities.OrderComposition;

public class OrderCompositionToGet
{
	public int Id { get; set; }
	public OrderToGet Order { get; set; }
	public ProductToGet Product { get; set; }
	public int Count { get; set; }
	public DateTimeOffset CreatedAt { get; set; }
	public DateTimeOffset UpdatedAt { get; set; }
}
