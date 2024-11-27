namespace Neon.Server.RequestEntities.History;

public class HistoryToGet
{
	public int Id { get; set; }
	public int UserId { get; set; }
	public int ProductId { get; set; }
	public DateTimeOffset Date { get; set; }
	public DateTimeOffset CreatedAt { get; set; }
	public DateTimeOffset UpdatedAt { get; set; }
}
