namespace Neon.Server.RequestEntities.History;

public class HistoryToPost
{
	public required int UserId { get; set; }
	public required int ProductId { get; set; }
	public required DateTimeOffset Date { get; set; }
}
