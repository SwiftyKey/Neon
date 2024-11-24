using Neon.Domain.Base;

namespace Neon.Application.Base;

public interface IReadRepository<TEntity> where TEntity : BaseAuditableEntity
{
	public IEnumerable<TEntity> GetAll();

	public TEntity GetByID(uint id);
}
