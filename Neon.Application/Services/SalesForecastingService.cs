using Neon.Application.IServices;

namespace Neon.Application.Services;

public class SalesForecastingService
(
	IOrderCompositionService orderCompositionService,
	IProductService productService
): ISalesForecastingService
{
	private double GetM(List<int> values) => (double)values.Sum(x => x) / values.Count;

	private Dictionary<string, List<int>> ProcessRecords()
	{
		return orderCompositionService
			.GetAll()
			.GroupBy(x => x.ProductId)
			.Select(x => new
			{
				ProductName = productService.GetById(x.Key).Name,
				Values = x
					.GroupBy(p => p.UpdatedAt.Date.Month)
					.Select(p => new
					{
						Month = p.Key,
						Count = p.Sum(y => y.Count)
					})
					.OrderBy(y => y.Month)
					.Select(y => y.Count)
					.ToList()
			})
			.ToDictionary(g => g.ProductName, g => g.Values);
	}

	public Dictionary<string, double> Forecast()
	{
		var products = ProcessRecords();

		return products
			.Where(p => p.Value.Count >= 3)
			.Select(p => new 
			{ 
				ProductName = p.Key, 
				Prediction = GetM(p.Value.TakeLast(3).ToList()) 
					+ (double)(p.Value[^1] - p.Value[^2]) / 3
			})
			.ToDictionary(g => g.ProductName, g => g.Prediction);
	}
}
