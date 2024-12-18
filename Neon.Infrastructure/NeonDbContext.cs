using Microsoft.EntityFrameworkCore;
using Neon.Domain.Entities;

namespace Neon.Infrastructure;

public class NeonDbContext : DbContext
{
	public DbSet<User> Users { get; set; }
	public DbSet<Product> Products { get; set; }
	public DbSet<Order> Orders { get; set; }
	public DbSet<Manufacturer> Manufacturers { get; set; }
	public DbSet<Category> Categories { get; set; }
	public DbSet<History> Histories { get; set; }
	public DbSet<OrderComposition> OrderCompositions { get; set; }

	public NeonDbContext(DbContextOptions<NeonDbContext> contextOptions) : base(contextOptions)
	{
		//Database.EnsureDeleted();
		Database.EnsureCreated();
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfigurationsFromAssembly(typeof(NeonDbContext).Assembly);
		base.OnModelCreating(modelBuilder);

		modelBuilder
			.Entity<User>()
			.HasMany(u => u.Products)
			.WithMany(p => p.Users)
			.UsingEntity<History>
			(
				j => j
					.HasOne(h => h.Product)
					.WithMany(pr => pr.History)
					.HasForeignKey(h => h.ProductId),
				j => j
					.HasOne(h => h.User)
					.WithMany(pr => pr.History)
					.HasForeignKey(h => h.UserId),
				j =>
				{
					j.Property(h => h.Date);
					j.HasKey(h => new { h.ProductId, h.UserId });
				}
			);

		modelBuilder
			.Entity<History>()
			.HasData
			(
				new History
				{
					Id = 1,
					UserId = 3,
					ProductId = 1,
					CreatedAt = DateTimeOffset.Now,
					UpdatedAt = DateTimeOffset.Now
				},
				new History
				{
					Id = 2,
					UserId = 3,
					ProductId = 11,
					CreatedAt = DateTimeOffset.Now,
					UpdatedAt = DateTimeOffset.Now
				},
				new History
				{
					Id = 3,
					UserId = 2,
					ProductId = 3,
					CreatedAt = DateTimeOffset.Now,
					UpdatedAt = DateTimeOffset.Now
				},
				new History
				{
					Id = 4,
					UserId = 3,
					ProductId = 2,
					CreatedAt = DateTimeOffset.Now,
					UpdatedAt = DateTimeOffset.Now
				},
				new History
				{
					Id = 5,
					UserId = 3,
					ProductId = 12,
					CreatedAt = DateTimeOffset.Now,
					UpdatedAt = DateTimeOffset.Now
				}
			);

		modelBuilder
			.Entity<Order>()
			.HasMany(u => u.Products)
			.WithMany(p => p.Orders)
			.UsingEntity<OrderComposition>
			(
				j => j
					.HasOne(oc => oc.Product)
					.WithMany(pr => pr.Compositions)
					.HasForeignKey(oc => oc.ProductId),
				j => j
					.HasOne(oc => oc.Order)
					.WithMany(pr => pr.Compositions)
					.HasForeignKey(oc => oc.OrderId),
				j =>
				{
					j.Property(oc => oc.Count);
					j.HasKey(oc => new { oc.ProductId, oc.OrderId });
				}
			);

		modelBuilder
			.Entity<OrderComposition>()
			.HasData
			(
				new OrderComposition
				{
					Id = 1,
					OrderId = 1,
					ProductId = 5,
					Count = 1,
					CreatedAt = DateTimeOffset.Now,
					UpdatedAt = DateTimeOffset.Now
				},
				new OrderComposition
				{
					Id = 2,
					OrderId = 2,
					ProductId = 5,
					Count = 2,
					CreatedAt = DateTimeOffset.Now,
					UpdatedAt = DateTimeOffset.Now
				},
				new OrderComposition
				{
					Id = 3,
					OrderId = 3,
					ProductId = 5,
					Count = 3,
					CreatedAt = DateTimeOffset.Now,
					UpdatedAt = DateTimeOffset.Now
				},
				new OrderComposition
				{
					Id = 4,
					OrderId = 4,
					ProductId = 5,
					Count = 1,
					CreatedAt = DateTimeOffset.Now,
					UpdatedAt = DateTimeOffset.Now
				},
				new OrderComposition
				{
					Id = 5,
					OrderId = 5,
					ProductId = 5,
					Count = 4,
					CreatedAt = DateTimeOffset.Now,
					UpdatedAt = DateTimeOffset.Now
				},
				new OrderComposition
				{
					Id = 6,
					OrderId = 6,
					ProductId = 5,
					Count = 3,
					CreatedAt = DateTimeOffset.Now,
					UpdatedAt = DateTimeOffset.Now
				},
				new OrderComposition
				{
					Id = 7,
					OrderId = 7,
					ProductId = 5,
					Count = 2,
					CreatedAt = DateTimeOffset.Now,
					UpdatedAt = DateTimeOffset.Now
				},
				new OrderComposition
				{
					Id = 8,
					OrderId = 8,
					ProductId = 5,
					Count = 2,
					CreatedAt = DateTimeOffset.Now,
					UpdatedAt = DateTimeOffset.Now
				},
				new OrderComposition
				{
					Id = 9,
					OrderId = 9,
					ProductId = 5,
					Count = 3,
					CreatedAt = DateTimeOffset.Now,
					UpdatedAt = DateTimeOffset.Now
				},
				new OrderComposition
				{
					Id = 10,
					OrderId = 10,
					ProductId = 5,
					Count = 1,
					CreatedAt = DateTimeOffset.Now,
					UpdatedAt = DateTimeOffset.Now
				},
				new OrderComposition
				{
					Id = 11,
					OrderId = 11,
					ProductId = 5,
					Count = 5,
					CreatedAt = DateTimeOffset.Now,
					UpdatedAt = DateTimeOffset.Now
				},
				new OrderComposition
				{
					Id = 12,
					OrderId = 12,
					ProductId = 5,
					Count = 7,
					CreatedAt = DateTimeOffset.Now,
					UpdatedAt = DateTimeOffset.Now
				}
			);
	}

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		optionsBuilder
			.UseSqlServer()
			.EnableSensitiveDataLogging();
		base.OnConfiguring(optionsBuilder);
	}
}