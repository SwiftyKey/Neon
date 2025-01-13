using Neon.Domain.Base;

namespace Neon.Domain.Entities;

public class Visit : BaseAuditableEntity
{
	public string Month { get; set; }
	public int Count { get; set; }
}
