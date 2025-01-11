using Neon.Application.IRepositories;
using Neon.Application.IServices;

namespace Neon.Application.Services;

public class ForecastingService(IVisitRepository visitRepository): IForecastingService
{
	private static int GetM(List<int> values) => values.Sum(x => x) / values.Count;

	public List<int> Forecast()
	{
		var data = visitRepository.GetAll().Select(v => v.Count).ToList();

		var predict = GetM(data.TakeLast(3).ToList()) + (data[^1] - data[^2]) / 3;

		data.Add(predict);

		return data;
	}
}
