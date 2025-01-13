using Neon.Application.IRepositories;
using Neon.Application.IServices;
using Neon.Domain.Entities;

namespace Neon.Application.Services;

public class ForecastingService(IVisitRepository visitRepository): IForecastingService
{
	private static int GetM(List<int> values) => values.Sum(x => x);

	public IEnumerable<Visit> Forecast()
	{
		var data = visitRepository.GetAll();

		var left = GetM(data.Select(x => x.Count).TakeLast(3).ToList());
		var right = (data.Select(x => x.Count).ToList()[^1] - data.Select(x => x.Count).ToList()[^2]);
		var predict =  (left + right) / 3;

		data = data.Append(new Visit { Count = predict, Month = "Декабрь"});

		return data;
	}
}
