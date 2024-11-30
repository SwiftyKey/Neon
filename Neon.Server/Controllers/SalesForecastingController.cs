using Microsoft.AspNetCore.Mvc;
using Neon.Application.IServices;
using Neon.Server.RequestEntities.User;

namespace Neon.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SalesForecastingController(ISalesForecastingService salesForecastingService) : ControllerBase
{
	[HttpGet(Name = nameof(GetForecast))]
	public ActionResult<UserToGet> GetForecast()
	{
		return Ok(salesForecastingService.Forecast());
	}
}
