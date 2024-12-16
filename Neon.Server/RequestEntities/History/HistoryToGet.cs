using Neon.Server.RequestEntities.Product;
using Neon.Server.RequestEntities.User;

namespace Neon.Server.RequestEntities.History;

public class HistoryToGet
{
	public int Id { get; set; }
	public UserToGet User { get; set; }
	public ProductToGet Product { get; set; }
	public DateTimeOffset Date { get; set; }
	public DateTimeOffset CreatedAt { get; set; }
	public DateTimeOffset UpdatedAt { get; set; }
}
