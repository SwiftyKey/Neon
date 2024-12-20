﻿using Neon.Application.ViewModels;
using Neon.Domain.Entities;

namespace Neon.Application.IServices;

public interface IUserService
{
	Task<UserVm> AddAsync(UserVm model);
	Task UpdateAsync(UserVm model);
	Task DeleteAsync(UserVm model);
	IEnumerable<UserVm> GetAll();
	UserVm GetById(int id);
	UserVm? GetByName(string name);
	Task ChangeRigths(bool rigths, int id);
	Task<string> Login(UserVm user);
}
