using Neon.Domain.Base;

namespace Neon.Domain.Entities;

public class User: BaseAuditableEntity
{
	public required string Name { get; set; }
	public required string HashPassword { get; set; }
	public required bool IsAdmin { get; set; }

	public ICollection<Product> Products { get; set; } = [];
	public ICollection<History> History { get; set; } = [];
	public ICollection<Order> Orders { get; set; } = [];
}
