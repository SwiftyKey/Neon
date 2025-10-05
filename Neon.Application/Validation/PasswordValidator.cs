using Neon.Application.ViewModels;

namespace Neon.Application.Validation;

public class PasswordValidator : ValidationHandler<UserVm>
{
	public override async Task HandleAsync(UserVm user)
	{
		if (string.IsNullOrEmpty(user.Password) || user.Password.Length < 12)
			throw new Exception("Некорректный пароль пользователя. Длина пароля должна быть больше 11");

		await base.HandleAsync(user);
	}
}