using Neon.Domain.Entities;

namespace Neon.Application.IServices;

public interface IProductService
{
	Task<Product> AddAsync(Product model);
	Task UpdateAsync(Product model);
	Task DeleteAsync(Product model);
	IEnumerable<Product> GetAll();
	Product GetById(uint id);
	Product? GetByName(string name);
}
