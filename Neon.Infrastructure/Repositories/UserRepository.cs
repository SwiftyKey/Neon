using Microsoft.EntityFrameworkCore;
using Neon.Application.IRepositories;
using Neon.Domain.Entities;

namespace Neon.Infrastructure.Repositories;

public class UserRepository: BaseRepository<User>, IUserRepository
{
	public UserRepository(NeonDbContext context) : base(context)
	{
		set = context.Users;
	}

	public override IEnumerable<User> GetAll() => [.. set
		.Include(u => u.Products)
		.ThenInclude(p => p.Manufacturer)
		.Include(u => u.Products)
		.ThenInclude(p => p.Category)
		.Include(u => u.History)
		.Include(u => u.Orders)
		.ThenInclude(o => o.Compositions)];

	public User GetById(int id) => set
		.Include(u => u.Products)
		.ThenInclude(p => p.Manufacturer)
		.Include(u => u.Products)
		.ThenInclude(p => p.Category)
		.Include(u => u.History)
		.Include(u => u.Orders)
		.ThenInclude(o => o.Compositions)
		.First(el => el.Id == id);

	public User? GetByName(string name) => set
		.Include(u => u.Products)
		.ThenInclude(p => p.Manufacturer)
		.Include(u => u.Products)
		.ThenInclude(p => p.Category)
		.Include(u => u.History)
		.Include(u => u.Orders)
		.ThenInclude(o => o.Compositions)
		.FirstOrDefault(u => u.Name == name);

	public void ChangeRights(bool rights, int id)
	{
		var user = GetById(id);
		user.IsAdmin = rights;
		set.Update(user);
	}
}
