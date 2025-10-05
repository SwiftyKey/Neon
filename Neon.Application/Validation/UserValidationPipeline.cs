using Neon.Application.ViewModels;

namespace Neon.Application.Validation;

public class UserValidationPipeline
{
	readonly IValidationHandler<UserVm>? _first;

	public UserValidationPipeline(IEnumerable<IValidationHandler<UserVm>> handlers)
	{
		IValidationHandler<UserVm>? current = null;

		foreach (var handler in handlers)
		{
			if (_first is null)
			{
				_first = handler;
				current = handler;
			}
			else
			{
				current = current!.SetNext(handler);
			}
		}
	}

	public async Task HandleAsync(UserVm user)
	{
		await _first!.HandleAsync(user);
	}
}
