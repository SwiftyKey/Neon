namespace Neon.Server.RequestEntities.Manufacturer;

public class ManufacturerToGet
{
	public uint Id { get; set; }
	public string Name { get; set; }
	public ICollection<Domain.Entities.Product> Products { get; set; } = [];
	public DateTimeOffset CreatedAt { get; set; }
	public DateTimeOffset UpdatedAt { get; set; }
}
