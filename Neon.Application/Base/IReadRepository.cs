using Neon.Domain.Base;

namespace Neon.Application.Base;

public interface IReadRepository<TEntity> where TEntity : BaseEntity
{
	public IEnumerable<TEntity> GetAll();

	public TEntity GetByID(int id);
}
