using Neon.Application.IRepositories;
using Neon.Domain.Entities;

namespace Neon.Infrastructure.Repositories;

public class UserRepository: BaseRepository<User>, IUserRepository
{
	public UserRepository(NeonDbContext context) : base(context)
	{
		set = context.Users;
	}

	public User? GetByName(string name) => set.FirstOrDefault(u => u.Name == name);

	public void ChangeRights(bool rights, uint id)
	{
		var user = GetByID(id);
		user.IsAdmin = rights;
		set.Update(user);
	}
}
