using Neon.Domain.Entities;

namespace Neon.Application.IServices;

public interface ICategoryService
{
	Task<Category> AddAsync(Category model);
	Task UpdateAsync(Category model);
	Task DeleteAsync(Category model);
	IEnumerable<Category> GetAll();
	Category GetById(int id);
	Category? GetByTitle(string title);
}
