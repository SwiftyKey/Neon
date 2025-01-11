using Neon.Application.IServices;

namespace Neon.Application.Services;

public class ForecastingService(): IForecastingService
{
	private double GetM(List<double> values) => values.Sum(x => x) / values.Count;

	public List<double> Forecast()
	{
		var data = new List<double> { 4, 5, 20, 23, 17, 21, 27, 31, 24, 29, 33 };

		var predict = GetM(data.TakeLast(3).ToList()) + (data[^1] - data[^2]) / 3;

		data.Add(predict);

		return data;
	}
}
