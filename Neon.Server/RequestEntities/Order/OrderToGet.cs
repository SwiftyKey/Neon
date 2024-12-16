using Neon.Server.RequestEntities.OrderComposition;
using Neon.Server.RequestEntities.User;

namespace Neon.Server.RequestEntities.Order;

public class OrderToGet
{
	public int Id { get; set; }
	public string Title { get; set; }
	public UserToGet User { get; set; }
	public ICollection<OrderCompositionToGet> Compositions { get; set; } = [];
	public DateTimeOffset CreatedAt { get; set; }
	public DateTimeOffset UpdatedAt { get; set; }
}
