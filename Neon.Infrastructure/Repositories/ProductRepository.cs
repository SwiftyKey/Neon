using Microsoft.EntityFrameworkCore;
using Neon.Application.IRepositories;
using Neon.Domain.Entities;

namespace Neon.Infrastructure.Repositories;

public class ProductRepository : BaseRepository<Product>, IProductRepository
{
	public ProductRepository(NeonDbContext context) : base(context)
	{
		set = context.Products;
	}

	public IEnumerable<Product> GetByName(string name) => [.. set
		.Include(c => c.Category)
		.Include(m => m.Manufacturer)
		.Where(p => EF.Functions.Like(p.Name.ToLower(), $"%{name.ToLower()}%"))];

	public override IEnumerable<Product> GetAll() => [.. set
		.Include(c => c.Category)
		.Include(m => m.Manufacturer)];
}
