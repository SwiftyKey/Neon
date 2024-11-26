using Neon.Domain.Base;

namespace Neon.Domain.Entities;

public class OrderComposition: BaseAuditableEntity
{
	public uint Count { get; set; }

	public uint OrderId { get; set; }
	public Order? Order { get; set; }

	public uint ProductId { get; set; }
	public Product? Product { get; set; }
}
