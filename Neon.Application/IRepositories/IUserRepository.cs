using Neon.Application.Base;
using Neon.Domain.Entities;

namespace Neon.Application.IRepositories;

public interface IUserRepository: IBaseRepository<User>
{
	User? GetByEmail(string email);
	User? GetByName(string name);
	User? GetByPhoneNumber(string phoneNumber);
	void ChangeRights(bool rights, int id);
}
