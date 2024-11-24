using Neon.Application.IRepositories;
using Neon.Application.IServices;
using Neon.Domain.Entities;

namespace Neon.Application.Services;

public class ManufacturerService
(
	IManufacturerRepository ManufacturerRepository
) : IManufacturerService
{
	public async Task<Manufacturer> AddAsync(Manufacturer model)
	{
		var manufacturer = await ManufacturerRepository.AddAsync(model);
		await ManufacturerRepository.SaveChangesAsync();
		return manufacturer;
	}

	public async Task DeleteAsync(Manufacturer model)
	{
		ManufacturerRepository.Delete(model);
		await ManufacturerRepository.SaveChangesAsync();
	}

	public IEnumerable<Manufacturer> GetAll()
	{
		return ManufacturerRepository.GetAll();
	}

	public Manufacturer GetById(uint id)
	{
		return ManufacturerRepository.GetByID(id);
	}

	public Manufacturer GetByName(string name)
	{
		return ManufacturerRepository.GetByName(name);
	}

	public async Task UpdateAsync(Manufacturer model)
	{
		ManufacturerRepository.Update(model);
		await ManufacturerRepository.SaveChangesAsync();
	}
}
