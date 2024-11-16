using Neon.Domain.Base;

namespace Neon.Domain.Entities;

public class ProductProperties: BaseEntity
{
	public required string PropertyName { get; set; }
	public required string PropertyValue { get; set; }

	public required int ProductId { get; set; }
	public required Product Product { get; set; }
}
