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
				Month = "Январь",
				Count = 4
			},
			new Visit
			{
				Id = 2,
				Month = "Февраль",
				Count = 5
			},
			new Visit
			{
				Id = 3,
				Month = "Март",
				Count = 20
			},
			new Visit
			{
				Id = 4,
				Month = "Апрель",
				Count = 23
			},
			new Visit
			{
				Id = 5,
				Month = "Май",
				Count = 17
			},
			new Visit
			{
				Id = 6,
				Month = "Июнь",
				Count = 21
			},
			new Visit
			{
				Id = 7,
				Month = "Июль",
				Count = 27
			},
			new Visit
			{
				Id = 8,
				Month = "Август",
				Count = 31
			},
			new Visit
			{
				Id = 9,
				Month = "Сентябрь",
				Count = 24
			},
			new Visit
			{
				Id = 10,
				Month = "Октябрь",
				Count = 29
			},
			new Visit
			{
				Id = 11,
				Month = "Ноябрь",
				Count = 33
			}
		);
	}
}
