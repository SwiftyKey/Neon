using Neon.Application.IRepositories;
using Neon.Domain.Entities;

namespace Neon.Infrastructure.Repositories;

public class VisitRepository: BaseRepository<Visit>, IVisitRepository
{
	public VisitRepository(NeonDbContext context) : base(context)
	{
		set = context.Visits;
	}
}
