using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Neon.Domain.Entities;

namespace Neon.Infrastructure.Contexts;

public class UserContext : IEntityTypeConfiguration<User>
{
	public void Configure(EntityTypeBuilder<User> builder)
	{
		builder
			.HasMany(u => u.Orders)
			.WithOne(o => o.User)
			.OnDelete(DeleteBehavior.ClientCascade);

		builder
			.HasIndex(u => u.Name)
			.IsUnique();

		builder
			.HasIndex(u => u.HashPassword)
			.IsUnique();

		builder.HasData
		(
			new User
			{
				Id = 1,
				Name = "Admin1",
				HashPassword = "A665A45920422F9D417E4867EFDC4FB8A04A1F3FFF1FA07E998E86F7F7A27AE3",
				IsAdmin = true,
				CreatedAt = DateTimeOffset.Now,
				UpdatedAt = DateTimeOffset.Now
			},
			new User
			{
				Id = 2,
				Name = "Admin2",
				HashPassword = "03AC674216F3E15C761EE1A5E255F067953623C8B388B4459E13F978D7C846F4",
				IsAdmin = true,
				CreatedAt = DateTimeOffset.Now,
				UpdatedAt = DateTimeOffset.Now
			},
			new User
			{
				Id = 3,
				Name = "Swifty",
				HashPassword = "F6E0A1E2AC41945A9AA7FF8A8AAA0CEBC12A3BCC981A929AD5CF810A090E11AE",
				IsAdmin = false,
				CreatedAt = DateTimeOffset.Now,
				UpdatedAt = DateTimeOffset.Now
			}
		);
	}
}