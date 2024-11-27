using Neon.Domain.Base;

namespace Neon.Domain.Entities;

public class History: BaseAuditableEntity
{
	public DateTimeOffset Date { get; set; }
	
	public int UserId { get; set; }
	public User? User { get; set; }

	public int ProductId { get; set; }
	public Product? Product { get; set; }
}
