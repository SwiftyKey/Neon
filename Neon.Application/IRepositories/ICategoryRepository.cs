using Neon.Application.Base;
using Neon.Domain.Entities;

namespace Neon.Application.IRepositories;

public interface ICategoryRepository: IBaseRepository<Category>
{
	Category? GetByTitle(string title);
	Category GetById(int id);
}
