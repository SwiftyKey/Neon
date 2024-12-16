﻿using Microsoft.EntityFrameworkCore;
using Neon.Application.IRepositories;
using Neon.Domain.Entities;

namespace Neon.Infrastructure.Repositories;

public class HistoryRepository: BaseRepository<History>, IHistoryRepository
{
	public HistoryRepository(NeonDbContext context) : base(context)
	{
		set = context.Histories;
	}

	public override IEnumerable<History> GetAll() => [.. set
		.Include(c => c.User)
		.Include(c => c.Product)];

	public History GetById(int id) => set
		.Include(c => c.User)
		.Include(c => c.Product)
		.First(el => el.Id == id);
}
