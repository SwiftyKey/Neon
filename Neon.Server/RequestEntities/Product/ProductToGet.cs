namespace Neon.Server.RequestEntities.Product;

public class ProductToGet
{
	public int Id { get; set; }
	public string Name { get; set; }
	public string Description { get; set; }
	public string Manufacturer { get; set; }
	public string Category { get; set; }
	public double Cost { get; set; }
	public int Count { get; set; }
	public DateTimeOffset CreatedAt { get; set; }
	public DateTimeOffset UpdatedAt { get; set; }
	public string ImagePath { get; set; }
}
