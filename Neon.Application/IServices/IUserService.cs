using Neon.Application.ViewModels;

namespace Neon.Application.IServices;

public interface IUserService
{
	Task<UserVm> AddAsync(UserVm model);
	Task UpdateAsync(UserVm model);
	Task DeleteAsync(UserVm model);
	IEnumerable<UserVm> GetAll();
	UserVm GetById(uint id);
	UserVm? GetByName(string name);
	Task ChangeRigths(bool rigths, uint id);
}
