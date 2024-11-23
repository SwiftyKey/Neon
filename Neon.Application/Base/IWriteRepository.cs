using Neon.Domain.Base;

namespace Neon.Application.Base;

public interface IWriteRepository<TEntity> where TEntity : BaseAuditableEntity
{
	Task<TEntity> AddAsync(TEntity entity);
	Task AddRangeAsync(IEnumerable<TEntity> entities);
	void Update(TEntity entity);
	void UpdateRange(IEnumerable<TEntity> entities);
	void Delete(TEntity entity);
	void DeleteRange(IEnumerable<TEntity> entities);
	Task SaveChangesAsync();
}