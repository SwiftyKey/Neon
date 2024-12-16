using Neon.Application.Base;
using Neon.Domain.Entities;

namespace Neon.Application.IRepositories;

public interface IManufacturerRepository: IBaseRepository<Manufacturer>
{
	Manufacturer? GetByName(string name);
	Manufacturer GetById(int id);
}
