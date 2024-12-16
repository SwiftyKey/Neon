using Microsoft.EntityFrameworkCore;
using Neon.Application.IRepositories;
using Neon.Domain.Entities;

namespace Neon.Infrastructure.Repositories;

public class ManufacturerRepository : BaseRepository<Manufacturer>, IManufacturerRepository
{
	public ManufacturerRepository(NeonDbContext context) : base(context)
	{
		set = context.Manufacturers;
	}

	public override IEnumerable<Manufacturer> GetAll() => [.. set
		.Include(c => c.Products)
		.ThenInclude(p => p.Category)];

	public Manufacturer GetById(int id) => set
		.Include(c => c.Products)
		.ThenInclude(p => p.Category)
		.First(el => el.Id == id);

	public Manufacturer? GetByName(string name) => set
		.Include(c => c.Products)
		.ThenInclude(p => p.Category)
		.FirstOrDefault(u => u.Name == name);
}
