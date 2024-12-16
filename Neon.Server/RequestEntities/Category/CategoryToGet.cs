using Neon.Server.RequestEntities.Product;

namespace Neon.Server.RequestEntities.Category;

public class CategoryToGet
{
	public int Id { get; set; }
	public string Title { get; set; }
	public ICollection<ProductToGet> Products { get; set; } = [];
	public DateTimeOffset CreatedAt { get; set; }
	public DateTimeOffset UpdatedAt { get; set; }
}
