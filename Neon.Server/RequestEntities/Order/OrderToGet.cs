using Neon.Server.RequestEntities.Product;

namespace Neon.Server.RequestEntities.Order;

public class OrderToGet
{
	public int Id { get; set; }
	public string Title { get; set; }
	public int UserId { get; set; }
	public bool Bought { get; set; }
	public ICollection<OC> Compositions { get; set; } = [];
	public DateTimeOffset CreatedAt { get; set; }
	public DateTimeOffset UpdatedAt { get; set; }
}

public class OC
{
	public int Id { get; set; }
	public ProductToGet Product { get; set; }
	public int Count { get; set; }
	public DateTimeOffset CreatedAt { get; set; }
	public DateTimeOffset UpdatedAt { get; set; }
}
