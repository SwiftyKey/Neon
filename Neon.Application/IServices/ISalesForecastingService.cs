namespace Neon.Application.IServices;

public interface ISalesForecastingService
{
	Dictionary<string, double> Forecast();
}
