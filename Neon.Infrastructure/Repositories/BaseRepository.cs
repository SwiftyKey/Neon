using Microsoft.EntityFrameworkCore;
using Neon.Application.Base;
using Neon.Domain.Base;

namespace Neon.Infrastructure.Repositories;

public abstract class BaseRepository<TEntity>(NeonDbContext context) : IBaseRepository<TEntity> where TEntity : BaseAuditableEntity
{
	private readonly NeonDbContext context = context;
	private protected DbSet<TEntity> set;

	public async Task<TEntity> AddAsync(TEntity entity)
	{
		entity.CreatedAt = DateTimeOffset.UtcNow;
		return (await set.AddAsync(entity)).Entity;
	}

	public async Task AddRangeAsync(IEnumerable<TEntity> entities)
	{
		foreach (var entity in entities)
			entity.CreatedAt = DateTimeOffset.UtcNow;
		await set.AddRangeAsync(entities);
	}

	public void Update(TEntity entity)
	{
		context.ChangeTracker.Clear();
		entity.UpdatedAt = DateTimeOffset.UtcNow;
		set.Update(entity);
	}

	public void UpdateRange(IEnumerable<TEntity> entities)
	{
		foreach (var entity in entities)
			entity.UpdatedAt = DateTimeOffset.UtcNow;
		set.UpdateRange(entities);
	}

	public void Delete(TEntity entity)
	{
		var entityToDelete = set.First(e => e.Id == entity.Id);
		set.Remove(entityToDelete);
	}

	public void DeleteRange(IEnumerable<TEntity> entities)
	{
		set.RemoveRange(entities);
	}

	public async Task SaveChangesAsync()
	{
		await context.SaveChangesAsync();
	}

	public virtual IEnumerable<TEntity> GetAll()
	{
		return set;
	}
}