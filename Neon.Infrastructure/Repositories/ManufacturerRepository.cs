using Neon.Application.IRepositories;
using Neon.Domain.Entities;

namespace Neon.Infrastructure.Repositories;

public class ManufacturerRepository : BaseRepository<Manufacturer>, IManufacturerRepository
{
	public ManufacturerRepository(NeonDbContext context) : base(context)
	{
		set = context.Manufacturers;
	}

	public Manufacturer? GetByName(string name) => set.FirstOrDefault(u => u.Name == name);
}
