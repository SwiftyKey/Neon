using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Neon.Domain.Entities;

namespace Neon.Infrastructure.Contexts;

public class ManufacturerContext : IEntityTypeConfiguration<Manufacturer>
{
	public void Configure(EntityTypeBuilder<Manufacturer> builder)
	{
		builder
			.HasMany(o => o.Products)
			.WithOne(c => c.Manufacturer)
			.OnDelete(DeleteBehavior.ClientCascade);

		builder
			.HasIndex(u => u.Name)
			.IsUnique();

		builder.HasData
		(
			new Manufacturer
			{
				Id = 1,
				Name = "Apple",
				CreatedAt = DateTimeOffset.Now,
				UpdatedAt = DateTimeOffset.Now
			},
			new Manufacturer
			{
				Id = 2,
				Name = "Raspberry Pi Foundation",
				CreatedAt = DateTimeOffset.Now,
				UpdatedAt = DateTimeOffset.Now
			},
			new Manufacturer
			{
				Id = 3,
				Name = "ASUS",
				CreatedAt = DateTimeOffset.Now,
				UpdatedAt = DateTimeOffset.Now
			},
			new Manufacturer
			{
				Id = 4,
				Name = "MSI",
				CreatedAt = DateTimeOffset.Now,
				UpdatedAt = DateTimeOffset.Now
			},
			new Manufacturer
			{
				Id = 5,
				Name = "Acer",
				CreatedAt = DateTimeOffset.Now,
				UpdatedAt = DateTimeOffset.Now
			},
			new Manufacturer
			{
				Id = 6,
				Name = "HP",
				CreatedAt = DateTimeOffset.Now,
				UpdatedAt = DateTimeOffset.Now
			},
			new Manufacturer
			{
				Id = 7,
				Name = "Canon",
				CreatedAt = DateTimeOffset.Now,
				UpdatedAt = DateTimeOffset.Now
			},
			new Manufacturer
			{
				Id = 8,
				Name = "Xerox",
				CreatedAt = DateTimeOffset.Now,
				UpdatedAt = DateTimeOffset.Now
			}
		);
	}
}