using Neon.Domain.Entities;

namespace Neon.Application.IServices;

public interface IManufacturerService
{
	Task<Manufacturer> AddAsync(Manufacturer model);
	Task UpdateAsync(Manufacturer model);
	Task DeleteAsync(Manufacturer model);
	IEnumerable<Manufacturer> GetAll();
	Manufacturer GetById(uint id);
	Manufacturer? GetByName(string name);
}
