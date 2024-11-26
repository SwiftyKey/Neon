using Neon.Application.IRepositories;
using Neon.Domain.Entities;

namespace Neon.Infrastructure.Repositories;

public class HistoryRepository: BaseRepository<History>, IHistoryRepository
{
	public HistoryRepository(NeonDbContext context) : base(context)
	{
		set = context.Histories;
	}
}
