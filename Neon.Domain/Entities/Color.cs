using Neon.Domain.Base;

namespace Neon.Domain.Entities;

public class Color: BaseEntity
{
	public required string Name { get; set; }
	public required string Value { get; set; }

	public virtual ICollection<Product> Products { get; set; } = [];
}
