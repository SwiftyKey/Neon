using MapsterMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Neon.Application.IServices;
using Neon.Server.RequestEntities.Order;
using Neon.Server.RequestEntities.OrderComposition;

namespace Neon.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class ProfileController
(
	IOrderService orderService,
	IOrderCompositionService orderCompositionService,
	IProductService productService,
	IPaymentService paymentService,
	IMapper mapper) : ControllerBase
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
		await paymentService.PayAsync(userId);
		return Ok();
	}

	[HttpPatch("cart/count/{userId:int}", Name = nameof(ChangeCount))]
	[Authorize(Roles = "Admin, Client")]
	public async Task<IActionResult> ChangeCount([FromRoute] int userId, [FromBody] OrderCompositionToChange orderCompositionToChange)
	{
		var cart = orderService.GetOrderByUserId(userId).First(x => !x.Bought);

		var composition = cart.Compositions.First(x => x.ProductId == orderCompositionToChange.ProductId);
		var product = productService.GetById(composition.ProductId);
		composition.Count = Math.Min(Math.Max(orderCompositionToChange.Count, 1), product.Count);
		await orderCompositionService.UpdateAsync(composition);

		return Ok();
	}

	[HttpDelete("cart/{userId:int}/{productId:int}", Name = nameof(DeleteItem))]
	[Authorize(Roles = "Admin, Client")]
	public async Task<IActionResult> DeleteItem([FromRoute] int userId, [FromRoute] int productId)
	{
		var cart = orderService.GetOrderByUserId(userId).First(x => !x.Bought);

		var composition = cart.Compositions.First(x => x.ProductId == productId);
		await orderCompositionService.DeleteAsync(composition);

		return Ok();
	}

	[HttpGet("/cart/totalPrice/{userId:int}")]
	[Authorize(Roles = "Admin, Client")]
	public ActionResult<double> GetTotalPrice(int userId)
	{
		var cart = orderService.GetOrderByUserId(userId).First(x => !x.Bought);
		var sum = cart.Compositions.Sum(x => x.Product.Cost * x.Count);
		return Ok(sum);
	}
}
