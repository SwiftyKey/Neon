using Neon.Domain.Base;

namespace Neon.Domain.Entities;

public class Order : BaseEntity
{
	public required string Name { get; set; }
	public required DateTime OrderDate { get; set; }

	public required int UserId { get; set; }
	public required User User { get; set; }

	public required int StatusId { get; set; }
	public required OrderStatus Status { get; set; }

	public virtual ICollection<OrderComposition> Composition { get; set; } = [];
}
