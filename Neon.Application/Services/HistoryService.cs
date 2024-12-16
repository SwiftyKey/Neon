using Neon.Application.IRepositories;
using Neon.Application.IServices;
using Neon.Domain.Entities;

namespace Neon.Application.Services;

public class HistoryService
(
	IHistoryRepository HistoryRepository
): IHistoryService
{
	public async Task<History> AddAsync(History model)
	{
		var history = await HistoryRepository.AddAsync(model);
		await HistoryRepository.SaveChangesAsync();
		return history;
	}

	public async Task DeleteAsync(History model)
	{
		HistoryRepository.Delete(model);
		await HistoryRepository.SaveChangesAsync();
	}

	public IEnumerable<History> GetAll()
	{
		return HistoryRepository.GetAll();
	}

	public History GetById(int id)
	{
		return HistoryRepository.GetById(id);
	}

	public async Task UpdateAsync(History model)
	{
		HistoryRepository.Update(model);
		await HistoryRepository.SaveChangesAsync();
	}
}
