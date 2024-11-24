namespace Neon.Server.RequestEntities.Product;

public class ProductToPatch
{
	public string? Name { get; set; }
	public string? Description { get; set; }
	public uint? ManufacturerId { get; set; }
	public uint? CategoryId { get; set; }
	public double? Cost { get; set; }
	public uint? Count { get; set; } = 1;
	public string? ImagePath { get; set; }
}
