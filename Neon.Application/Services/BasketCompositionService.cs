using MapsterMapper;
using Neon.Application.IRepositories;
using Neon.Application.IServices;
using Neon.Application.ViewModels;
using Neon.Domain.Entities;

namespace Neon.Application.Services;

public class BasketCompositionService
(
	IMapper mapper,
	IBasketCompositionRepository basketCompositionRepository
) : IBasketCompositionService
{
	public async Task<BasketCompositionVm> AddAsync(BasketCompositionVm model)
	{
		var bc = mapper.Map<BasketComposition>(model);
		bc = await basketCompositionRepository.AddAsync(bc);
		await basketCompositionRepository.SaveChangesAsync();
		return mapper.Map<BasketCompositionVm>(bc);
	}

	public async Task DeleteAsync(BasketCompositionVm model)
	{
		basketCompositionRepository.Delete(mapper.Map<BasketComposition>(model));
		await basketCompositionRepository.SaveChangesAsync();
	}

	public IEnumerable<BasketCompositionVm> GetAll()
	{
		return basketCompositionRepository.GetAll().Select(mapper.Map<BasketCompositionVm>);
	}

	public BasketCompositionVm GetById(int id)
	{
		return mapper.Map<BasketCompositionVm>(basketCompositionRepository.GetByID(id));
	}

	public async Task UpdateAsync(BasketCompositionVm model)
	{
		var entity = basketCompositionRepository.GetByID(model.Id);
		var updatedEntity = mapper.Map(model, entity);

		basketCompositionRepository.Update(updatedEntity);
		await basketCompositionRepository.SaveChangesAsync();
	}

	public ICollection<Product> GetProductsByUserId(int userId)
	{
		var products = basketCompositionRepository.GetProductsByUserId(userId);
		return products;
	}
}
