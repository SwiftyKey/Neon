using Neon.Application.Base;
using Neon.Domain.Entities;

namespace Neon.Application.IRepositories;

public interface IBasketCompositionRepository: IBaseRepository<BasketComposition>
{
	ICollection<Product> GetProductsByUserId(int userId);
}