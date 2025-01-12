using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Neon.Domain.Entities;

namespace Neon.Infrastructure.Contexts;

public class OrderContext : IEntityTypeConfiguration<Order>
{
	public void Configure(EntityTypeBuilder<Order> builder)
	{
		builder
			.HasIndex(u => u.Title);

		builder
			.HasData
			(
				new Order
				{
					Id = 1,
					Title = "1" + DateTimeOffset.Now.Ticks.ToString(),
					UserId = 1,
					Bought = true,
					CreatedAt = DateTimeOffset.Now,
					UpdatedAt = DateTimeOffset.Now
				},
				new Order
				{
					Id = 2,
					Title = "1" + DateTimeOffset.Now.Ticks.ToString(),
					UserId = 1,
					Bought = true,
					CreatedAt = DateTimeOffset.Now,
					UpdatedAt = DateTimeOffset.Now
				},
				new Order
				{
					Id = 3,
					Title = "1" + DateTimeOffset.Now.Ticks.ToString(),
					UserId = 1,
					Bought = true,
					CreatedAt = DateTimeOffset.Now,
					UpdatedAt = DateTimeOffset.Now
				},
				new Order
				{
					Id = 4,
					Title = "1" + DateTimeOffset.Now.Ticks.ToString(),
					UserId = 1,
					Bought = true,
					CreatedAt = DateTimeOffset.Now,
					UpdatedAt = DateTimeOffset.Now
				},
				new Order
				{
					Id = 5,
					Title = "2" + DateTimeOffset.Now.Ticks.ToString(),
					UserId = 2,
					Bought = true,
					CreatedAt = DateTimeOffset.Now,
					UpdatedAt = DateTimeOffset.Now
				},
				new Order
				{
					Id = 6,
					Title = "2" + DateTimeOffset.Now.Ticks.ToString(),
					UserId = 2,
					Bought = true,
					CreatedAt = DateTimeOffset.Now,
					UpdatedAt = DateTimeOffset.Now
				},
				new Order
				{
					Id = 7,
					Title = "2" + DateTimeOffset.Now.Ticks.ToString(),
					UserId = 2,
					Bought = true,
					CreatedAt = DateTimeOffset.Now,
					UpdatedAt = DateTimeOffset.Now
				},
				new Order
				{
					Id = 8,
					Title = "2" + DateTimeOffset.Now.Ticks.ToString(),
					UserId = 2,
					Bought = true,
					CreatedAt = DateTimeOffset.Now,
					UpdatedAt = DateTimeOffset.Now
				},
				new Order
				{
					Id = 9,
					Title = "3" + DateTimeOffset.Now.Ticks.ToString(),
					UserId = 3,
					Bought = true,
					CreatedAt = DateTimeOffset.Now,
					UpdatedAt = DateTimeOffset.Now
				},
				new Order
				{
					Id = 10,
					Title = "3" + DateTimeOffset.Now.Ticks.ToString(),
					UserId = 3,
					Bought = true,
					CreatedAt = DateTimeOffset.Now,
					UpdatedAt = DateTimeOffset.Now
				},
				new Order
				{
					Id = 11,
					Title = "3" + DateTimeOffset.Now.Ticks.ToString(),
					UserId = 3,
					Bought = true,
					CreatedAt = DateTimeOffset.Now,
					UpdatedAt = DateTimeOffset.Now
				},
				new Order
				{
					Id = 12,
					Title = "3" + DateTimeOffset.Now.Ticks.ToString(),
					UserId = 3,
					Bought = true,
					CreatedAt = DateTimeOffset.Now,
					UpdatedAt = DateTimeOffset.Now
				}
			);
	}
}