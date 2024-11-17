using Neon.Domain.Base;

namespace Neon.Domain.Entities;

public class User: BaseEntity
{
	public required string Name { get; set; }
	public required string HashPassword { get; set; }
	public required string Email { get; set; }
	public string? PhoneNumber { get; set; }
	public required bool IsAdmin { get; set; }
	public required DateTime RegistrationDate { get; set; }

	public virtual ICollection<BasketComposition> Basket { get; set; } = [];
	public virtual ICollection<ReservationHistory> History { get; set; } = [];
	public virtual ICollection<Order> Orders { get; set; } = [];
}
