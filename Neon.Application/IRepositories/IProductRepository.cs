using Neon.Application.Base;
using Neon.Domain.Entities;

namespace Neon.Application.IRepositories;

public interface IProductRepository: IBaseRepository<Product>
{
	IEnumerable<Product> GetByName(string name);
}
