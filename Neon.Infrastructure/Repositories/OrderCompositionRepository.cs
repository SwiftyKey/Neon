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
		.ThenInclude(o => o.User)
		.Include(c => c.Product)
		.ThenInclude(p => p.Manufacturer)
		.Include(c => c.Product)
		.ThenInclude(p => p.Category)];

	public OrderComposition GetById(int id) => set
		.Include(c => c.Order)
		.ThenInclude(o => o.User)
		.Include(c => c.Product)
		.ThenInclude(p => p.Manufacturer)
		.Include(c => c.Product)
		.ThenInclude(p => p.Category)
		.First(el => el.Id == id);

	public IEnumerable<OrderComposition> GetCompositionsByOrderId(int id) => [.. set
		.Include(c => c.Order)
		.ThenInclude(o => o.User)
		.Include(c => c.Product)
		.ThenInclude(p => p.Manufacturer)
		.Include(c => c.Product)
		.ThenInclude(p => p.Category)
		.Where(oc => oc.OrderId == id)];
}
