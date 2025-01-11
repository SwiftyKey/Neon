using Neon.Application.Base;
using Neon.Domain.Entities;

namespace Neon.Application.IRepositories;

public interface IOrderRepository: IBaseRepository<Order>
{
	Order? GetByTitle(string title);
	Order GetById(int id);
	IEnumerable<Order> GetOrderByUserId(int userId);
}
