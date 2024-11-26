namespace Neon.Server.RequestEntities.History;

public class HistoryToPatch
{
	public uint? UserId { get; set; }
	public uint? ProductId { get; set; }
	public DateTimeOffset? Date { get; set; }
}
