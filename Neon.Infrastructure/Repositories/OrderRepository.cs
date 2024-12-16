using Microsoft.EntityFrameworkCore;
using Neon.Application.IRepositories;
using Neon.Domain.Entities;

namespace Neon.Infrastructure.Repositories;

public class OrderRepository : BaseRepository<Order>, IOrderRepository
{
	public OrderRepository(NeonDbContext context) : base(context)
	{
		set = context.Orders;
	}

	public override IEnumerable<Order> GetAll() => [.. set
		.Include(c => c.User)
		.Include(c => c.Products)
		.Include(c => c.Compositions)];

	public Order GetById(int id) => set
		.Include(c => c.User)
		.Include(c => c.Products)
		.Include(c => c.Compositions)
		.First(el => el.Id == id);

	public Order? GetByTitle(string title) => set
		.Include(c => c.User)
		.Include(c => c.Products)
		.Include(c => c.Compositions)
		.FirstOrDefault(u => u.Title == title);
}
