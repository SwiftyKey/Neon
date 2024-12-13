namespace Neon.Server.RequestEntities.History;

public class HistoryToGet
{
	public int Id { get; set; }
	public Domain.Entities.User User { get; set; }
	public Domain.Entities.Product Product{ get; set; }
	public DateTimeOffset Date { get; set; }
	public DateTimeOffset CreatedAt { get; set; }
	public DateTimeOffset UpdatedAt { get; set; }
}
