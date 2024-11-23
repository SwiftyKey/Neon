using Neon.Application.IRepositories;
using Neon.Application.IServices;
using Neon.Domain.Entities;

namespace Neon.Application.Services;

public class CategoryService
(
	ICategoryRepository CategoryRepository
) : ICategoryService
{
	public async Task<Category> AddAsync(Category model)
	{
		var order = await CategoryRepository.AddAsync(model);
		await CategoryRepository.SaveChangesAsync();
		return order;
	}

	public async Task DeleteAsync(Category model)
	{
		CategoryRepository.Delete(model);
		await CategoryRepository.SaveChangesAsync();
	}

	public IEnumerable<Category> GetAll()
	{
		return CategoryRepository.GetAll();
	}

	public Category GetById(int id)
	{
		return CategoryRepository.GetByID(id);
	}

	public Category GetByTitle(string title)
	{
		return CategoryRepository.GetByTitle(title);
	}

	public async Task UpdateAsync(Category model)
	{
		CategoryRepository.Update(model);
		await CategoryRepository.SaveChangesAsync();
	}
}
