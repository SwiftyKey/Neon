using Neon.Domain.Entities;

namespace Neon.Application.IServices;

public interface IForecastingService
{
	IEnumerable<Visit> Forecast();
}
