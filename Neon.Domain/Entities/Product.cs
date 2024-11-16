using Neon.Domain.Base;
using Neon.Domain.Enums;

namespace Neon.Domain.Entities;

public class Product : BaseEntity
{
	public required string Name { get; set; }
	public string? Description { get; set; }
	public required WarrantyPeriod WarrantyPertiod { get; set; }
	public required double Cost { get; set; }

	public required int ColorId { get; set; }
	public required Color Color { get; set; }

	public required int ModelId { get; set; }
	public required Model Model { get; set; }

	public required int StorageId { get; set; }
	public required Storage Storage { get; set; }

	public virtual ICollection<ProductProperties> Properties { get; set; } = [];
	public virtual ICollection<BasketComposition> InBaskets { get; set; } = [];
	public virtual ICollection<ReservationHistory> InHistories { get; set; } = [];
	public virtual ICollection<OrderComposition> InOrders { get; set; } = [];
}
