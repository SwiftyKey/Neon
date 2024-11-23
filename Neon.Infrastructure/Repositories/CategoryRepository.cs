using Neon.Application.IRepositories;
using Neon.Domain.Entities;

namespace Neon.Infrastructure.Repositories;

public class CategoryRepository: BaseRepository<Category>, ICategoryRepository
{
	public CategoryRepository(NeonDbContext context) : base(context)
	{
		set = context.Categories;
	}

	public Category? GetByTitle(string title) => set.FirstOrDefault(u => u.Title == title);
}
