namespace Neon.Server.RequestEntities.OrderComposition;

public class OrderCompositionToPost
{
	public required int OrderId { get; set; }
	public required int ProductId { get; set; }
	public required int Count { get; set; }
}
