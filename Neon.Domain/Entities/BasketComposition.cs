using Neon.Domain.Base;

namespace Neon.Domain.Entities;

public class BasketComposition: BaseEntity
{
	public required int UserId { get; set; }
	public required User User { get; set; }

	public required int ProductId { get; set; }
	public required Product Product { get; set; }
}
