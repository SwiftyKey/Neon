using Neon.Domain.Entities;

namespace Neon.Application.IServices;

public interface IOrderService
{
	Task<Order> AddAsync(Order model);
	Task UpdateAsync(Order model);
	Task DeleteAsync(Order model);
	IEnumerable<Order> GetAll();
	Order GetById(int id);
	Order? GetByTitle(string title);
	IEnumerable<Order> GetOrderByUserId(int userId);
	Task<Order> CreateCartByUserId(int userId);
}
