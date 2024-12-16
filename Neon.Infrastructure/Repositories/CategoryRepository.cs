using Microsoft.EntityFrameworkCore;
using Neon.Application.IRepositories;
using Neon.Domain.Entities;

namespace Neon.Infrastructure.Repositories;

public class CategoryRepository: BaseRepository<Category>, ICategoryRepository
{
	public CategoryRepository(NeonDbContext context) : base(context)
	{
		set = context.Categories;
	}

	public override IEnumerable<Category> GetAll() => [.. set
		.Include(c => c.Products)
		.ThenInclude(p => p.Category)];

	public Category GetById(int id) => set
		.Include(c => c.Products)
		.ThenInclude(p => p.Manufacturer)
		.First(el => el.Id == id);

	public Category? GetByTitle(string title) => set
		.Include(c => c.Products)
		.ThenInclude(p => p.Manufacturer)
		.FirstOrDefault(u => u.Title == title);
}
