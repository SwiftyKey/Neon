using Neon.Domain.Base;

namespace Neon.Domain.Entities;

public class Manufacturer: BaseEntity
{
	public required string Name { get; set; }

	public virtual ICollection<Model> Models { get; set; } = [];
}
