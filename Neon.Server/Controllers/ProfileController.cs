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
	[Authorize(Roles = "Admin, Client")]
	public ActionResult<IEnumerable<OrderToGet>> GetUserOrders([FromRoute] int userId)
	{
		var orders = orderService.GetOrderByUserId(userId).Where(x => x.Bought);
		return Ok(orders.Select(mapper.Map<OrderToGet>));
	}

	[HttpGet("cart/{userId:int}", Name = nameof(GetUserCart))]
	[Authorize(Roles = "Admin, Client")]
	public async Task<ActionResult<IEnumerable<OrderToGet>>> GetUserCart([FromRoute] int userId)
	{
		var cart = orderService.GetOrderByUserId(userId).FirstOrDefault(x => !x.Bought);
		cart ??= await orderService.CreateCartByUserId(userId);

		return Ok(mapper.Map<OrderToGet>(cart));
	}

	[HttpPatch("cart/{userId:int}", Name = nameof(Payment))]
	[Authorize(Roles = "Admin, Client")]
	public async Task<IActionResult> Payment([FromRoute] int userId)
	{
		var cart = orderService.GetOrderByUserId(userId).First(x => !x.Bought);
		cart.Bought = true;

		await orderService.UpdateAsync(cart);
		await orderService.CreateCartByUserId(userId);

		return Ok();
	}
}
