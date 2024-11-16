using Neon.Domain.Base;

namespace Neon.Domain.Entities;

public class CategoryProperties: BaseEntity
{
	public required int CategoryId { get; set; }
	public required Category Category { get; set; }

	public required int PropertyId { get; set; }
	public required Properties Property { get; set; }
}
