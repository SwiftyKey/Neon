namespace Neon.Server.RequestEntities.History;

public class HistoryToPatch
{
	public int? UserId { get; set; }
	public int? ProductId { get; set; }
	public DateTimeOffset? Date { get; set; }
}
