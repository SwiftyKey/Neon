using Neon.Domain.Base;

namespace Neon.Domain.Entities;

public class Manufacturer: BaseAuditableEntity
{
	public required string Name { get; set; }

	public virtual ICollection<Product> Products { get; set; } = [];
}
