namespace Neon.Server.RequestEntities.Order;

public class OrderToPost
{
	public required string Title { get; set; }
	public required uint UserId { get; set; }
}
