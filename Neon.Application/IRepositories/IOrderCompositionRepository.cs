using Neon.Application.Base;
using Neon.Domain.Entities;

namespace Neon.Application.IRepositories;

public interface IOrderCompositionRepository: IBaseRepository<OrderComposition>
{
	OrderComposition GetById(int id);
}
