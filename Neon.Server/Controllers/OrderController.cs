﻿using MapsterMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Neon.Application.IServices;
using Neon.Domain.Entities;
using Neon.Server.RequestEntities.Order;

namespace Neon.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class OrderController(IOrderService orderService, IMapper mapper) : ControllerBase
{
	[HttpGet("{orderId:int}", Name = nameof(GetOrderById))]
	public ActionResult<OrderToGet> GetOrderById([FromRoute] int orderId)
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
	[Authorize(Roles = "Admin")]
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
	[Authorize(Roles = "Admin")]
	public async Task<IActionResult> UpdateOrder(int orderId, [FromBody] OrderToPatch orderToPatch)
	{
		var order = mapper.Map<Order>(orderToPatch);
		order.Id = orderId;
		await orderService.UpdateAsync(order);
		return Ok();
	}

	[HttpDelete("{orderId:int}", Name = nameof(DeleteOrder))]
	[Authorize(Roles = "Admin")]
	public async Task<IActionResult> DeleteOrder(int orderId)
	{
		await orderService.DeleteAsync(orderService.GetById(orderId));
		return Ok();
	}
}
