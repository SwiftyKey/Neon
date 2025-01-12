using Neon.Application.ViewModels;
using Neon.Domain.Entities;

namespace Neon.Application.IServices;

public interface IUserService
{
	Task<UserVm> AddAsync(UserVm model);
	Task UpdateAsync(UserVm model);
	Task DeleteAsync(UserVm model);
	IEnumerable<User> GetAll();
	User GetById(int id);
	User? GetByName(string name);
	Task ChangeRights(bool rigths, int id);
	Task<string> Login(UserVm user);
}
