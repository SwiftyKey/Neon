namespace Neon.Server.RequestEntities.History;

public class HistoryToPost
{
	public required uint UserId { get; set; }
	public required uint ProductId { get; set; }
	public required DateTimeOffset Date { get; set; }
}
