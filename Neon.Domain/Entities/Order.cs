using Neon.Domain.Base;

namespace Neon.Domain.Entities;

public class Order : BaseAuditableEntity
{
	public required string Title { get; set; }

	public required int UserId { get; set; }
	public User User { get; set; }
	public bool Bought { get; set; }

	public ICollection<Product> Products { get; set; } = [];
	public ICollection<OrderComposition> Compositions { get; set; } = [];
}
