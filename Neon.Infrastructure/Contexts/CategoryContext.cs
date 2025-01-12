using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Neon.Domain.Entities;

namespace Neon.Infrastructure.Contexts;

public class CategoryContext : IEntityTypeConfiguration<Category>
{
	public void Configure(EntityTypeBuilder<Category> builder)
	{
		builder
			.HasMany(o => o.Products)
			.WithOne(c => c.Category)
			.OnDelete(DeleteBehavior.Cascade);

		builder
			.HasIndex(u => u.Title)
			.IsUnique();

		builder.HasData
		(
			new Category
			{
				Id = 1,
				Title = "Компьютеры",
				CreatedAt = DateTimeOffset.Now,
				UpdatedAt = DateTimeOffset.Now
			},
			new Category
			{
				Id = 2,
				Title = "Ноутбуки",
				CreatedAt = DateTimeOffset.Now,
				UpdatedAt = DateTimeOffset.Now
			},
			new Category
			{
				Id = 3,
				Title = "Сканеры",
				CreatedAt = DateTimeOffset.Now,
				UpdatedAt = DateTimeOffset.Now
			},
			new Category
			{
				Id = 4,
				Title = "Принтеры",
				CreatedAt = DateTimeOffset.Now,
				UpdatedAt = DateTimeOffset.Now
			},
			new Category
			{
				Id = 5,
				Title = "Плоттеры",
				CreatedAt = DateTimeOffset.Now,
				UpdatedAt = DateTimeOffset.Now
			},
			new Category
			{
				Id = 6,
				Title = "Микрокомпьютеры",
				CreatedAt = DateTimeOffset.Now,
				UpdatedAt = DateTimeOffset.Now
			}
		);
	}
}