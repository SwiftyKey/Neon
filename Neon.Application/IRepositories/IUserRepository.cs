using Neon.Application.Base;
using Neon.Application.ViewModels;
using Neon.Domain.Entities;

namespace Neon.Application.IRepositories;

public interface IUserRepository: IBaseRepository<User>
{
	User? GetByName(string name);
	User GetById(int id);
	Task<User?> Login(UserVm user);
	void ChangeRights(bool rights, int id);
}
