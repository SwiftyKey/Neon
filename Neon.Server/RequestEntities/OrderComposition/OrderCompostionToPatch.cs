namespace Neon.Server.RequestEntities.OrderComposition;

public class OrderCompostionToPatch
{
	public uint? OrderId { get; set; }
	public uint? ProductId { get; set; }
	public uint? Count { get; set; }
}
