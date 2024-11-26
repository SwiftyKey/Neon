namespace Neon.Server.RequestEntities.OrderComposition;

public class OrderCompositionToGet
{
	public uint Id { get; set; }
	public uint OrderId { get; set; }
	public uint ProductId { get; set; }
	public uint Count { get; set; }
	public DateTimeOffset CreatedAt { get; set; }
	public DateTimeOffset UpdatedAt { get; set; }
}
