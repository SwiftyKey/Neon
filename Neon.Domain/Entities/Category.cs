using Neon.Domain.Base;

namespace Neon.Domain.Entities;

public class Category: BaseEntity
{
	public required string Name { get; set; }
	public int ParentId { get; set; }
	public Category? Parent { get; set; }

	public virtual ICollection<Category> Children { get; set; } = [];
	public virtual ICollection<CategoryProperties> Properties { get; set; } = [];
	public virtual ICollection<Model> Models { get; set; } = [];
}
