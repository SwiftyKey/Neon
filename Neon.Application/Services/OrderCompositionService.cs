using Neon.Application.IRepositories;
using Neon.Application.IServices;
using Neon.Domain.Entities;

namespace Neon.Application.Services;

public class OrderCompositionService
(
	IOrderCompositionRepository OrderCompositionRepository
): IOrderCompositionService
{
	public async Task<OrderComposition> AddAsync(OrderComposition model)
	{
		var history = await OrderCompositionRepository.AddAsync(model);
		await OrderCompositionRepository.SaveChangesAsync();
		return history;
	}

	public async Task DeleteAsync(OrderComposition model)
	{
		OrderCompositionRepository.Delete(model);
		await OrderCompositionRepository.SaveChangesAsync();
	}

	public IEnumerable<OrderComposition> GetAll()
	{
		return OrderCompositionRepository.GetAll();
	}

	public OrderComposition GetById(int id)
	{
		return OrderCompositionRepository.GetById(id);
	}

	public async Task UpdateAsync(OrderComposition model)
	{
		OrderCompositionRepository.Update(model);
		await OrderCompositionRepository.SaveChangesAsync();
	}
}
