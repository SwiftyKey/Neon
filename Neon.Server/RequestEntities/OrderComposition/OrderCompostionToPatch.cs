namespace Neon.Server.RequestEntities.OrderComposition;

public class OrderCompostionToPatch
{
	public int? OrderId { get; set; }
	public int? ProductId { get; set; }
	public int? Count { get; set; }
}
