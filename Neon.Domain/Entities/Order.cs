using Neon.Domain.Base;

namespace Neon.Domain.Entities;

public class Order : BaseAuditableEntity
{
	public required string Title { get; set; }

	public required int UserId { get; set; }
	public required User User { get; set; }

	public ICollection<Product> Products { get; set; } = [];
	public ICollection<OrderComposition> Compositions { get; set; } = [];
}
