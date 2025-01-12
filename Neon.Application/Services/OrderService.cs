using Neon.Application.IRepositories;
using Neon.Application.IServices;
using Neon.Domain.Entities;

namespace Neon.Application.Services;

public class OrderService
(
	IOrderRepository OrderRepository
) : IOrderService
{
	public async Task<Order> AddAsync(Order model)
	{
		var order = await OrderRepository.AddAsync(model);
		await OrderRepository.SaveChangesAsync();
		return order;
	}

	public async Task DeleteAsync(Order model)
	{
		OrderRepository.Delete(model);
		await OrderRepository.SaveChangesAsync();
	}

	public IEnumerable<Order> GetAll()
	{
		return OrderRepository.GetAll();
	}

	public Order GetById(int id)
	{
		return OrderRepository.GetById(id);
	}

	public Order GetByTitle(string title)
	{
		return OrderRepository.GetByTitle(title);
	}

	public async Task UpdateAsync(Order model)
	{
		OrderRepository.Update(model);
		await OrderRepository.SaveChangesAsync();
	}

	public IEnumerable<Order> GetOrderByUserId(int userId)
	{
		return OrderRepository.GetOrderByUserId(userId);
	}

	public async Task<Order> CreateCartByUserId(int userId)
	{
		var cart = await OrderRepository.CreateCartByUserId(userId);
		await OrderRepository.SaveChangesAsync();
		return cart;
	}
}
