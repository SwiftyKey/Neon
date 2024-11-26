using Neon.Domain.Base;

namespace Neon.Domain.Entities;

public class Category: BaseAuditableEntity
{
	public required string Title { get; set; }

	public ICollection<Product> Products { get; set; } = [];
}
