using Neon.Domain.Base;

namespace Neon.Domain.Entities;

public class Model: BaseEntity
{
	public required string Name { get; set; }
	public required double Length { get; set; }
	public required double Width { get; set; }
	public required double Height { get; set; }

	public required int CategoryId { get; set; }
	public required Category Category { get; set; }

	public required int ManufacturerId { get; set; }
	public required Manufacturer Manufacturer { get; set; }

	public virtual ICollection<Product> Products { get; set; } = [];
}
