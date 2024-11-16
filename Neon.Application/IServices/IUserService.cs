using Neon.Application.ViewModels;

namespace Neon.Application.IServices;

public interface IUserService
{
	Task<UserVm> AddAsync(UserVm model);
	Task UpdateAsync(UserVm model);
	Task DeleteAsync(UserVm model);
	IEnumerable<UserVm> GetAll();
	UserVm GetById(int id);
	UserVm? GetByEmail(string email);
	UserVm? GetByName(string name);
	UserVm? GetByPhoneNumber(string phoneNumber);
	Task ChangeRigths(bool rigths, int id);
}
