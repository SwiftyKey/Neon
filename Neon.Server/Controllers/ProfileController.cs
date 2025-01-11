using MapsterMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Neon.Application.IServices;
using Neon.Server.RequestEntities.Order;

namespace Neon.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class ProfileController(IOrderService orderService, IMapper mapper) : ControllerBase
{
	[HttpGet("orders/{userId:int}", Name = nameof(GetUserOrders))]
	public ActionResult<IEnumerable<OrderToGet>> GetUserOrders([FromRoute] int userId)
	{
		var orders = orderService.GetOrderByUserId(userId);
		return Ok(orders.Select(mapper.Map<OrderToGet>));
	}
}
