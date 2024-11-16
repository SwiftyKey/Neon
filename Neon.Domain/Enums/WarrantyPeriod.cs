using System.ComponentModel.DataAnnotations;

namespace Neon.Domain.Enums;

public enum WarrantyPeriod
{
	[Display(Name = "Год")]
	Year,
	[Display(Name = "2 Года")]
	TwoYears,
	[Display(Name = "3 Года")]
	ThreeYears,
	[Display(Name = "4 Года")]
	FourYears,
	[Display(Name = "5 Лет")]
	FiveYears
}
