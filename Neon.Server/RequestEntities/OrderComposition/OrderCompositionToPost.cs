namespace Neon.Server.RequestEntities.OrderComposition;

public class OrderCompositionToPost
{
	public required uint OrderId { get; set; }
	public required uint ProductId { get; set; }
	public required uint Count { get; set; }
}
