using Microsoft.EntityFrameworkCore;
using Neon.Domain.Entities;

namespace Neon.Infrastructure;

public class NeonDbContext: DbContext
{
	public DbSet<User> Users { get; set; }
	public DbSet<Product> Products { get; set; }
	public DbSet<Order> Orders { get; set; }
	public DbSet<Manufacturer> Manufacturers { get; set; }
	public DbSet<Category> Categories { get; set; }

	public NeonDbContext(DbContextOptions<NeonDbContext> contextOptions): base(contextOptions)
	{
		//Database.EnsureDeleted();
		Database.EnsureCreated();
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder
			.Entity<User>()
			.HasMany(u => u.Orders)
			.WithOne(o => o.User)
			.OnDelete(DeleteBehavior.ClientCascade);

		modelBuilder
			.Entity<User>()
			.HasIndex(u => u.Name)
			.IsUnique();

		modelBuilder
			.Entity<User>()
			.HasIndex(u => u.HashPassword)
			.IsUnique();

		modelBuilder
			.Entity<Order>()
			.HasIndex(u => u.Title)
			.IsUnique();

		modelBuilder
			.Entity<Manufacturer>()
			.HasMany(o => o.Products)
			.WithOne(c => c.Manufacturer)
			.OnDelete(DeleteBehavior.ClientCascade);

		modelBuilder
			.Entity<Manufacturer>()
			.HasIndex(u => u.Name)
			.IsUnique();

		modelBuilder
			.Entity<Category>()
			.HasMany(o => o.Products)
			.WithOne(c => c.Category)
			.OnDelete(DeleteBehavior.ClientCascade);

		modelBuilder
			.Entity<Category>()
			.HasIndex(u => u.Title)
			.IsUnique();

		modelBuilder
			.Entity<Product>()
			.HasIndex(u => u.Name)
			.IsUnique();

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
}
