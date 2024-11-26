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
	[HttpGet("{orderCompositionId:uint}", Name = nameof(GetOrderCompositionById))]
	public ActionResult<OrderCompositionToGet> GetOrderCompositionById([FromRoute] uint orderCompositionId)
	{
		var orderComposition = orderCompositionService.GetById(orderCompositionId);
		if (orderComposition is null)
			return NotFound();
		var orderCompositionToGet = mapper.Map<OrderCompositionToGet>(orderComposition);
		return Ok(orderCompositionToGet);
	}

	[HttpGet(Name = nameof(GetAllHistories))]
	public ActionResult<IEnumerable<OrderCompositionToGet>> GetAllHistories()
	{
		var histories = orderCompositionService.GetAll();
		return Ok(histories.Select(mapper.Map<OrderCompositionToGet>));
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

	[HttpPatch("{orderCompositionId:uint}", Name = nameof(UpdateOrderComposition))]
	public async Task<IActionResult> UpdateOrderComposition(uint orderCompositionId, [FromBody] OrderCompostionToPatch orderCompositionToPatch)
	{
		var orderComposition = mapper.Map<OrderComposition>(orderCompositionToPatch);
		orderComposition.Id = orderCompositionId;
		await orderCompositionService.UpdateAsync(orderComposition);
		return Ok();
	}

	[HttpDelete("{orderCompositionId:uint}", Name = nameof(DeleteOrderComposition))]
	public async Task<IActionResult> DeleteOrderComposition(uint orderCompositionId)
	{
		await orderCompositionService.DeleteAsync(orderCompositionService.GetById(orderCompositionId));
		return Ok();
	}
}
