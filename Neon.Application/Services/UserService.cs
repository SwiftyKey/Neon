using Neon.Application.Base;
using Neon.Application.IRepositories;
using Neon.Application.IServices;
using Neon.Application.ViewModels;
using Neon.Domain.Entities;
using MapsterMapper;
using Neon.Application.Contracts;

namespace Neon.Application.Services;

public class UserService
(
	IMapper mapper,
	IUserRepository userRepository,
	IHasher hasher,
	IJwtProvider jwtProvider
) : IUserService
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

	public IEnumerable<User> GetAll()
	{
		return userRepository.GetAll();
	}

	public User GetById(int id)
	{
		return userRepository.GetById(id);
	}

	public User? GetByName(string name)
	{
		return userRepository.GetByName(name);
	}

	public async Task UpdateAsync(UserVm model)
	{
		var entity = userRepository.GetById(model.Id);
		var updatedEntity = mapper.Map(model, entity);

		userRepository.Update(updatedEntity);
		await userRepository.SaveChangesAsync();
	}

	public async Task ChangeRigths(bool rigths, int id)
	{
		userRepository.ChangeRights(rigths, id);
		await userRepository.SaveChangesAsync();
	}

	public async Task<string> Login(UserVm user)
	{
		user.Password = hasher.Hash(user.Password);
		var u = await userRepository.Login(user);
		if (u == null)
			return string.Empty;
		return jwtProvider.GenerateToken(u);
	}
}
