using Neon.Domain.Base;

namespace Neon.Domain.Entities;

public class Product : BaseAuditableEntity
{
	public required string Name { get; set; }
	public string? Description { get; set; }
	public required double Cost { get; set; }
	public required int Count { get; set; }
	public string? ImagePath { get; set; }

	public required int CategoryId { get; set; }
	public required Category Category { get; set; }

	public required int ManufacturerId { get; set; }
	public required Manufacturer Manufacturer { get; set; }

	public ICollection<History> History { get; set; } = [];
	public ICollection<OrderComposition> Compositions { get; set; } = [];
	public ICollection<User> Users { get; set; } = [];
	public ICollection<Order> Orders { get; set; } = [];
}
