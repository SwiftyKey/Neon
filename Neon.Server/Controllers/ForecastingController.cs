﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Neon.Application.IServices;
using Neon.Server.RequestEntities.User;

namespace Neon.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class ForecastingController(IForecastingService forecastingService) : ControllerBase
{
	[HttpGet(Name = nameof(GetForecast))]
	[Authorize(Policy = "AdminPolicy")]
	public ActionResult<UserToGet> GetForecast()
	{
		return Ok(forecastingService.Forecast());
	}
}
