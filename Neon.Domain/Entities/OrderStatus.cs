using Neon.Domain.Base;

namespace Neon.Domain.Entities;

public class OrderStatus: BaseEntity
{
	public required string Name { get; set; }

	public virtual ICollection<Order> Orders { get; set; } = [];
}
