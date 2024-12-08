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
					.HasForeignKey(h => h.UserId),
				j => j
					.HasOne(h => h.User)
					.WithMany(pr => pr.History)
					.HasForeignKey(h => h.ProductId),
				j =>
				{
					j.Property(h => h.Date);
					j.HasKey(h => new { h.ProductId, h.UserId });
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
					.HasForeignKey(oc => oc.OrderId),
				j => j
					.HasOne(oc => oc.Order)
					.WithMany(pr => pr.Compositions)
					.HasForeignKey(oc => oc.ProductId),
				j =>
				{
					j.Property(oc => oc.Count);
					j.HasKey(oc => new { oc.ProductId, oc.OrderId });
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