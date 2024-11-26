namespace Neon.Server.RequestEntities.History;

public class HistoryToGet
{
	public uint Id { get; set; }
	public uint UserId { get; set; }
	public uint ProductId { get; set; }
	public DateTimeOffset Date { get; set; }
	public DateTimeOffset CreatedAt { get; set; }
	public DateTimeOffset UpdatedAt { get; set; }
}
