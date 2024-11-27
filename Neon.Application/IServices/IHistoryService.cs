using Neon.Domain.Entities;

namespace Neon.Application.IServices;

public interface IHistoryService
{
	Task<History> AddAsync(History model);
	Task UpdateAsync(History model);
	Task DeleteAsync(History model);
	IEnumerable<History> GetAll();
	History GetById(int id);
}
