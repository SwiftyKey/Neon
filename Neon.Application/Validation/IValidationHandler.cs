namespace Neon.Application.Validation;

public interface IValidationHandler<T>
{
	IValidationHandler<T> SetNext(IValidationHandler<T> next);
	Task HandleAsync(T entity);
}
