using Neon.Application.ViewModels;

namespace Neon.Application.Validation;

public class NameValidator : ValidationHandler<UserVm>
{

	public override async Task HandleAsync(UserVm user)
	{
		if (string.IsNullOrEmpty(user.Name) || user.Name.Length < 3)
			throw new Exception("Некорректное имя пользователя. Длина имени должна быть больше 2");

		await base.HandleAsync(user);
	}
}
