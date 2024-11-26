using Neon.Domain.Entities;

namespace Neon.Application.IServices;

public interface IOrderCompositionService
{
	Task<OrderComposition> AddAsync(OrderComposition model);
	Task UpdateAsync(OrderComposition model);
	Task DeleteAsync(OrderComposition model);
	IEnumerable<OrderComposition> GetAll();
	OrderComposition GetById(uint id);
}
