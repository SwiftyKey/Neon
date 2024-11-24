namespace Neon.Server.RequestEntities.Product;

public class ProductToGet
{
	public uint Id { get; set; }
	public string Name { get; set; }
	public string Description { get; set; }
	public uint ManufacturerId { get; set; }
	public uint Categoryid { get; set; }
	public double Cost { get; set; }
	public uint Count { get; set; }
	public DateTimeOffset CreatedAt { get; set; }
	public DateTimeOffset UpdatedAt { get; set; }
	public string ImagePath { get; set; }
}
