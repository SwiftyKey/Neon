using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Neon.Domain.Entities;

namespace Neon.Infrastructure.Contexts;

public class VisitContext : IEntityTypeConfiguration<Visit>
{
	public void Configure(EntityTypeBuilder<Visit> builder)
	{
		builder.HasData
		(
			new Visit
			{
				Id = 1,
				Month = 1,
				Count = 4
			},
			new Visit
			{
				Id = 2,
				Month = 2,
				Count = 5
			},
			new Visit
			{
				Id = 3,
				Month = 3,
				Count = 20
			},
			new Visit
			{
				Id = 4,
				Month = 4,
				Count = 23
			},
			new Visit
			{
				Id = 5,
				Month = 5,
				Count = 17
			},
			new Visit
			{
				Id = 6,
				Month = 6,
				Count = 21
			},
			new Visit
			{
				Id = 7,
				Month = 7,
				Count = 27
			},
			new Visit
			{
				Id = 8,
				Month = 8,
				Count = 31
			},
			new Visit
			{
				Id = 9,
				Month = 9,
				Count = 24
			},
			new Visit
			{
				Id = 10,
				Month = 10,
				Count = 29
			},
			new Visit
			{
				Id = 11,
				Month = 11,
				Count = 33
			}
		);
	}
}
