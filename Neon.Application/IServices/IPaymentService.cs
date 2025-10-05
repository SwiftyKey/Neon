namespace Neon.Application.IServices;

public interface IPaymentService
{
	Task PayAsync(int userId);
}
