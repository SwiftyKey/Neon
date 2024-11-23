using Neon.Application.IRepositories;
using Neon.Domain.Entities;

namespace Neon.Infrastructure.Repositories;

public class ProductRepository : BaseRepository<Product>, IProductRepository
{
	public ProductRepository(NeonDbContext context) : base(context)
	{
		set = context.Products;
	}

	public Product? GetByName(string name) => set.FirstOrDefault(u => u.Name == name);
}
