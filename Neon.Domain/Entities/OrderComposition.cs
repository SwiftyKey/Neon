using Neon.Domain.Base;

namespace Neon.Domain.Entities;

public class OrderComposition: BaseEntity
{
	public required int Count { get; set; }

	public required int OrderId { get; set; }
	public required Order Order { get; set; }

	public required int ProductId { get; set; }
	public required Product Product { get; set; }
}
