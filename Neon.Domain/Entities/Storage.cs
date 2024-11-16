using Neon.Domain.Base;

namespace Neon.Domain.Entities;

public class Storage: BaseEntity
{
	public required int ProductId { get; set; }
	public required Product Product { get; set; }
	public required int Count { get; set; }
}
