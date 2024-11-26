using Neon.Application.IRepositories;
using Neon.Domain.Entities;

namespace Neon.Infrastructure.Repositories;

public class OrderCompositionRepository: BaseRepository<OrderComposition>, IOrderCompositionRepository
{
	public OrderCompositionRepository(NeonDbContext context) : base(context)
	{
		set = context.OrderCompositions;
	}
}
