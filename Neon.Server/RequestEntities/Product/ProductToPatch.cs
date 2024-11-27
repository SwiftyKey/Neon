namespace Neon.Server.RequestEntities.Product;

public class ProductToPatch
{
	public string? Name { get; set; }
	public string? Description { get; set; }
	public int? ManufacturerId { get; set; }
	public int? CategoryId { get; set; }
	public double? Cost { get; set; }
	public int? Count { get; set; } = 1;
	public string? ImagePath { get; set; }
}
