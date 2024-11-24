namespace Neon.Server.RequestEntities.Product;

public class ProductToPost
{
	public required string Name { get; set; }
	public string? Description { get; set; }
	public required uint ManufacturerId { get; set; }
	public required uint CategoryId { get; set; }
	public required double Cost { get; set; }
	public uint Count { get; set; } = 1;
	public string? ImagePath { get; set; }
}
