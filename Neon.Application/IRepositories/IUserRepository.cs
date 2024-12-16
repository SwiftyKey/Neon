using Neon.Application.Base;
using Neon.Domain.Entities;

namespace Neon.Application.IRepositories;

public interface IUserRepository: IBaseRepository<User>
{
	User? GetByName(string name);
	User GetById(int id);
	void ChangeRights(bool rights, int id);
}
