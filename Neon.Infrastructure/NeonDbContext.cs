using Microsoft.EntityFrameworkCore;
using Neon.Domain.Entities;

namespace Neon.Infrastructure;

public class NeonDbContext: DbContext
{
	public DbSet<User> Users { get; set; }
	public DbSet<Storage> Storage { get; set; }
	public DbSet<ReservationHistory> ReservationHistory { get; set; }
	public DbSet<Properties> Properties { get; set; }
	public DbSet<ProductProperties> ProductProperties { get; set; }
	public DbSet<Product> Products { get; set; }
	public DbSet<OrderStatus> OrderStatuses { get; set; }
	public DbSet<OrderComposition> OrderCompositions { get; set; }
	public DbSet<Order> Orders { get; set; }
	public DbSet<Model> Models { get; set; }
	public DbSet<Manufacturer> Manufacturers { get; set; }
	public DbSet<Color> Colors { get; set; }
	public DbSet<CategoryProperties> CategoryProperties { get; set; }
	public DbSet<Category> Categories { get; set; }
	public DbSet<BasketComposition> BasketCompositions { get; set; }


	public NeonDbContext(DbContextOptions<NeonDbContext> contextOptions): base(contextOptions)
	{
		//Database.EnsureDeleted();
		Database.EnsureCreated();
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder
			.Entity<User>()
			.HasMany(u => u.Basket)
			.WithOne(b => b.User)
			.OnDelete(DeleteBehavior.ClientCascade);

		modelBuilder
			.Entity<User>()
			.HasMany(u => u.Orders)
			.WithOne(o => o.User)
			.OnDelete(DeleteBehavior.ClientCascade);

		modelBuilder
			.Entity<User>()
			.HasMany(u => u.History)
			.WithOne(h => h.User)
			.OnDelete(DeleteBehavior.ClientCascade);

		modelBuilder
			.Entity<User>()
			.HasIndex(u => u.Email)
			.IsUnique();

		modelBuilder
			.Entity<User>()
			.HasIndex(u => u.Name)
			.IsUnique();

		modelBuilder
			.Entity<User>()
			.HasIndex(u => u.PhoneNumber)
			.IsUnique();

		modelBuilder
			.Entity<User>()
			.HasIndex(u => u.HashPassword)
			.IsUnique();

		modelBuilder
			.Entity<OrderStatus>()
			.HasMany(o => o.Orders)
			.WithOne(or => or.Status)
			.OnDelete(DeleteBehavior.ClientCascade);

		modelBuilder
			.Entity<OrderStatus>()
			.HasIndex(u => u.Name)
			.IsUnique();

		modelBuilder
			.Entity<Order>()
			.HasMany(o => o.Composition)
			.WithOne(c => c.Order)
			.OnDelete(DeleteBehavior.ClientCascade);

		modelBuilder
			.Entity<Order>()
			.HasIndex(u => u.Name)
			.IsUnique();

		modelBuilder
			.Entity<Color>()
			.HasMany(o => o.Products)
			.WithOne(c => c.Color)
			.OnDelete(DeleteBehavior.ClientCascade);

		modelBuilder
			.Entity<Color>()
			.HasIndex(u => u.Name)
			.IsUnique();

		modelBuilder
			.Entity<Color>()
			.HasIndex(u => u.Value)
			.IsUnique();

		modelBuilder
			.Entity<Storage>()
			.HasOne(o => o.Product)
			.WithOne(c => c.Storage)
			.HasForeignKey<Product>(c => c.StorageId)
			.OnDelete(DeleteBehavior.ClientCascade);

		modelBuilder
			.Entity<Storage>()
			.HasIndex(u => u.ProductId)
			.IsUnique();

		modelBuilder
			.Entity<Product>()
			.HasMany(o => o.InHistories)
			.WithOne(c => c.Product)
			.OnDelete(DeleteBehavior.ClientCascade);

		modelBuilder
			.Entity<Product>()
			.HasMany(o => o.InBaskets)
			.WithOne(c => c.Product)
			.OnDelete(DeleteBehavior.ClientCascade);

		modelBuilder
			.Entity<Product>()
			.HasMany(o => o.InOrders)
			.WithOne(c => c.Product)
			.OnDelete(DeleteBehavior.ClientCascade);

		modelBuilder
			.Entity<Product>()
			.HasMany(o => o.Properties)
			.WithOne(c => c.Product)
			.OnDelete(DeleteBehavior.ClientCascade);

		modelBuilder
			.Entity<Product>()
			.HasIndex(u => u.Name)
			.IsUnique();

		modelBuilder
			.Entity<Manufacturer>()
			.HasMany(o => o.Models)
			.WithOne(c => c.Manufacturer)
			.OnDelete(DeleteBehavior.ClientCascade);

		modelBuilder
			.Entity<Manufacturer>()
			.HasIndex(u => u.Name)
			.IsUnique();

		modelBuilder
			.Entity<Properties>()
			.HasMany(o => o.Categories)
			.WithOne(c => c.Property)
			.OnDelete(DeleteBehavior.ClientCascade);

		modelBuilder
			.Entity<Properties>()
			.HasIndex(u => u.Name)
			.IsUnique();

		modelBuilder
			.Entity<Category>()
			.HasMany(o => o.Children)
			.WithOne(c => c.Parent)
			.OnDelete(DeleteBehavior.ClientCascade);

		modelBuilder
			.Entity<Category>()
			.HasMany(o => o.Properties)
			.WithOne(c => c.Category)
			.OnDelete(DeleteBehavior.ClientCascade);

		modelBuilder
			.Entity<Category>()
			.HasIndex(u => u.Name)
			.IsUnique();

		modelBuilder
			.Entity<Category>()
			.HasMany(o => o.Models)
			.WithOne(c => c.Category)
			.OnDelete(DeleteBehavior.ClientCascade);

		modelBuilder
			.Entity<Category>()
			.HasIndex(u => u.Name)
			.IsUnique();

		modelBuilder
			.Entity<Model>()
			.HasMany(o => o.Products)
			.WithOne(c => c.Model)
			.OnDelete(DeleteBehavior.ClientCascade);

		modelBuilder
			.Entity<Model>()
			.HasIndex(u => u.Name)
			.IsUnique();
	}
}
