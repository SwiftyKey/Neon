namespace Neon.Application.Validation;

public abstract class ValidationHandler<T> : IValidationHandler<T>
{
	IValidationHandler<T>? _next;

	public IValidationHandler<T> SetNext(IValidationHandler<T> next)
	{
		_next = next;
		return next;
	}

	public virtual async Task HandleAsync(T entity)
	{
		if (_next != null)
			await _next.HandleAsync(entity);
	}
}
