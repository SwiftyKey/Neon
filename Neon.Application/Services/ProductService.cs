using Neon.Application.IRepositories;
using Neon.Application.IServices;
using Neon.Domain.Entities;

namespace Neon.Application.Services;

public class ProductService
(
	IProductRepository ProductRepository
) : IProductService
{
	public async Task<Product> AddAsync(Product model)
	{
		var product = await ProductRepository.AddAsync(model);
		await ProductRepository.SaveChangesAsync();
		return product;
	}

	public async Task DeleteAsync(Product model)
	{
		ProductRepository.Delete(model);
		await ProductRepository.SaveChangesAsync();
	}

	public IEnumerable<Product> GetAll()
	{
		return ProductRepository.GetAll();
	}

	public Product GetById(int id)
	{
		return ProductRepository.GetById(id);
	}

	public IEnumerable<Product> GetByName(string name)
	{
		return ProductRepository.GetByName(name);
	}

	public async Task UpdateAsync(Product model)
	{
		ProductRepository.Update(model);
		await ProductRepository.SaveChangesAsync();
	}
}
