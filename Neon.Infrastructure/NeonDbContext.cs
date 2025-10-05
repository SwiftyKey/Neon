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
				}
			);
	}

	//protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	//{
	//	optionsBuilder
	//		.UseSqlServer()
	//		.EnableSensitiveDataLogging();
	//	base.OnConfiguring(optionsBuilder);
	//}
}