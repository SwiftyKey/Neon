using Neon.Domain.Entities;

namespace Neon.Application.IServices;

public interface IBasketCompositionService
{
	ICollection<Product> GetProductsByUserId(int userId);
}
