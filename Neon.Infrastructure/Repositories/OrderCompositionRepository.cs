using Microsoft.EntityFrameworkCore;
using Neon.Application.IRepositories;
using Neon.Domain.Entities;

namespace Neon.Infrastructure.Repositories;

public class OrderCompositionRepository: BaseRepository<OrderComposition>, IOrderCompositionRepository
{
	public OrderCompositionRepository(NeonDbContext context) : base(context)
	{
		set = context.OrderCompositions;
	}

	public override IEnumerable<OrderComposition> GetAll() => [.. set
		.Include(c => c.Order)
		.Include(c => c.Product)];

	public OrderComposition GetById(int id) => set
		.Include(c => c.Order)
		.Include(c => c.Product)
		.First(el => el.Id == id);
}
