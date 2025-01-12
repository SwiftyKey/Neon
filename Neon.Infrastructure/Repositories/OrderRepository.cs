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

	public IEnumerable<Order> GetOrderByUserId(int userId) => [.. set
		.Include(c => c.User)
		.Include(c => c.Products)
		.Include(c => c.Compositions)
		.Where(u => u.UserId == userId)];

	public async Task<Order> CreateCartByUserId(int userId)
	{
		var order = new Order { Title = $"{userId}{DateTimeOffset.Now.Ticks}", UserId = userId };
		return await AddAsync(order);
	}
}
