using Neon.Domain.Base;

namespace Neon.Domain.Entities;

public class Properties: BaseEntity
{
	public required string Name { get; set; }

	public virtual ICollection<CategoryProperties> Categories { get; set; } = [];
}
