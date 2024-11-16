using Neon.Application.IRepositories;
using Neon.Domain.Entities;

namespace Neon.Infrastructure.Repositories;

public class UserRepository: BaseRepository<User>, IUserRepository
{
	public UserRepository(NeonDbContext context) : base(context)
	{
		set = context.Users;
	}

	public User? GetByEmail(string email) => set.FirstOrDefault(u => u.Email == email);

	public User? GetByName(string name) => set.FirstOrDefault(u => u.Name == name);

	public User? GetByPhoneNumber(string phoneNumber) => set.FirstOrDefault(u => u.PhoneNumber == phoneNumber);

	public void ChangeRights(bool rights, int id)
	{
		var user = GetByID(id);
		user.IsAdmin = rights;
		set.Update(user);
	}
}
