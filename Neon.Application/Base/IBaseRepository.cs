using Neon.Domain.Base;

namespace Neon.Application.Base;

public interface IBaseRepository<TEntity> : IWriteRepository<TEntity>, IReadRepository<TEntity> where TEntity : BaseEntity
{
}
