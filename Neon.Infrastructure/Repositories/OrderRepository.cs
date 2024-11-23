using Neon.Application.IRepositories;
using Neon.Domain.Entities;

namespace Neon.Infrastructure.Repositories;

public class OrderRepository : BaseRepository<Order>, IOrderRepository
{
	public OrderRepository(NeonDbContext context) : base(context)
	{
		set = context.Orders;
	}

	public Order? GetByTitle(string title) => set.FirstOrDefault(u => u.Title == title);
}
