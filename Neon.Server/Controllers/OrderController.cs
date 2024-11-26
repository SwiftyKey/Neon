using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using Neon.Application.IServices;
using Neon.Domain.Entities;
using Neon.Server.RequestEntities.Order;

namespace Neon.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderController(IOrderService orderService, IMapper mapper) : ControllerBase
{
	[HttpGet("{orderId:int}", Name = nameof(GetOrderById))]
	public ActionResult<OrderToGet> GetOrderById([FromRoute] uint orderId)
	{
		var order = orderService.GetById(orderId);
		if (order is null)
			return NotFound();
		var orderToGet = mapper.Map<OrderToGet>(order);
		return Ok(orderToGet);
	}

	[HttpGet("{title}", Name = nameof(GetOrderByTitle))]
	public ActionResult<OrderToGet> GetOrderByTitle([FromRoute] string title)
	{
		var order = orderService.GetByTitle(title);
		if (order is null)
			return NotFound();
		var orderToGet = mapper.Map<OrderToGet>(order);
		return Ok(orderToGet);
	}

	[HttpGet(Name = nameof(GetAllOrders))]
	public ActionResult<IEnumerable<OrderToGet>> GetAllOrders()
	{
		var orders = orderService.GetAll();
		return Ok(orders.Select(mapper.Map<OrderToGet>));
	}

	[HttpPost(Name = nameof(CreateOrder))]
	public async Task<IActionResult> CreateOrder([FromBody] OrderToPost orderToPost)
	{
		if (orderToPost is null)
			return BadRequest("Order is empty");
		if (!ModelState.IsValid)
			return UnprocessableEntity();
		var order = mapper.Map<Order>(orderToPost);
		var createdOrder = await orderService.AddAsync(order);
		return CreatedAtRoute(nameof(GetOrderById), new { orderId = createdOrder.Id }, createdOrder.Id);
	}

	[HttpPatch("{orderId:int}", Name = nameof(UpdateOrder))]
	public async Task<IActionResult> UpdateOrder(uint orderId, [FromBody] OrderToPatch orderToPatch)
	{
		var order = mapper.Map<Order>(orderToPatch);
		order.Id = orderId;
		await orderService.UpdateAsync(order);
		return Ok();
	}

	[HttpDelete("{orderId:int}", Name = nameof(DeleteOrder))]
	public async Task<IActionResult> DeleteOrder(uint orderId)
	{
		await orderService.DeleteAsync(orderService.GetById(orderId));
		return Ok();
	}
}
