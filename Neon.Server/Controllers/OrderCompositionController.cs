using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using Neon.Application.IServices;
using Neon.Domain.Entities;
using Neon.Server.RequestEntities.OrderComposition;

namespace Neon.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderCompositionController(IOrderCompositionService orderCompositionService, IMapper mapper) : ControllerBase
{
	[HttpGet("{orderCompositionId:int}", Name = nameof(GetOrderCompositionById))]
	public ActionResult<OrderCompositionToGet> GetOrderCompositionById([FromRoute] int orderCompositionId)
	{
		var orderComposition = orderCompositionService.GetById(orderCompositionId);
		if (orderComposition is null)
			return NotFound();
		var orderCompositionToGet = mapper.Map<OrderCompositionToGet>(orderComposition);
		return Ok(orderCompositionToGet);
	}

	[HttpGet(Name = nameof(GetAllOrderCompositions))]
	public ActionResult<IEnumerable<OrderCompositionToGet>> GetAllOrderCompositions()
	{
		var orderCompositions = orderCompositionService.GetAll();
		return Ok(orderCompositions.Select(mapper.Map<OrderCompositionToGet>));
	}

	[HttpGet("{orderId:int}", Name = nameof(GetCompositionsByOrderId))]
	public ActionResult<IEnumerable<OrderCompositionToGet>> GetCompositionsByOrderId(int orderId)
	{
		var orderCompositions = orderCompositionService.GetCompositionsByOrderId(orderId);
		return Ok(orderCompositions.Select(mapper.Map<OrderCompositionToGet>));
	}

	[HttpPost(Name = nameof(CreateOrderComposition))]
	public async Task<IActionResult> CreateOrderComposition([FromBody] OrderCompositionToPost orderCompositionToPost)
	{
		if (orderCompositionToPost is null)
			return BadRequest("OrderComposition is empty");
		if (!ModelState.IsValid)
			return UnprocessableEntity();
		var orderComposition = mapper.Map<OrderComposition>(orderCompositionToPost);
		var createdOrderComposition = await orderCompositionService.AddAsync(orderComposition);
		return CreatedAtRoute(nameof(GetOrderCompositionById), new { orderCompositionId = createdOrderComposition.Id }, createdOrderComposition.Id);
	}

	[HttpPatch("{orderCompositionId:int}", Name = nameof(UpdateOrderComposition))]
	public async Task<IActionResult> UpdateOrderComposition(int orderCompositionId, [FromBody] OrderCompostionToPatch orderCompositionToPatch)
	{
		var orderComposition = mapper.Map<OrderComposition>(orderCompositionToPatch);
		orderComposition.Id = orderCompositionId;
		await orderCompositionService.UpdateAsync(orderComposition);
		return Ok();
	}

	[HttpDelete("{orderCompositionId:int}", Name = nameof(DeleteOrderComposition))]
	public async Task<IActionResult> DeleteOrderComposition(int orderCompositionId)
	{
		await orderCompositionService.DeleteAsync(orderCompositionService.GetById(orderCompositionId));
		return Ok();
	}
}
