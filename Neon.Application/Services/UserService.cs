using Neon.Application.Base;
using Neon.Application.IRepositories;
using Neon.Application.IServices;
using Neon.Application.ViewModels;
using Neon.Domain.Entities;
using MapsterMapper;

namespace Neon.Application.Services;

public class UserService
(
	IMapper mapper,
	IUserRepository userRepository,
	IHasher hasher
): IUserService
{
	public async Task<UserVm> AddAsync(UserVm model)
	{
		var user = mapper.Map<User>(model);
		user.HashPassword = hasher.Hash(model.Password);
		user = await userRepository.AddAsync(user);
		await userRepository.SaveChangesAsync();
		return mapper.Map<UserVm>(user);
	}

	public async Task DeleteAsync(UserVm model)
	{
		userRepository.Delete(mapper.Map<User>(model));
		await userRepository.SaveChangesAsync();
	}

	public IEnumerable<UserVm> GetAll()
	{
		return userRepository.GetAll().Select(mapper.Map<UserVm>);
	}

	public UserVm GetById(uint id)
	{
		return mapper.Map<UserVm>(userRepository.GetByID(id));
	}

	public UserVm GetByName(string name)
	{
		return mapper.Map<UserVm>(userRepository.GetByName(name));
	}

	public async Task UpdateAsync(UserVm model)
	{
		var entity = userRepository.GetByID(model.Id);
		var updatedEntity = mapper.Map(model, entity);

		userRepository.Update(updatedEntity);
		await userRepository.SaveChangesAsync();
	}

	public async Task ChangeRigths(bool rigths, uint id)
	{
		userRepository.ChangeRights(rigths, id);
		await userRepository.SaveChangesAsync();
	}
}
