using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using Neon.Application.IServices;
using Neon.Domain.Entities;
using Neon.Server.RequestEntities.History;

namespace Neon.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HistoryController(IHistoryService historyService, IMapper mapper) : ControllerBase
{
	[HttpGet("{historyId:uint}", Name = nameof(GetHistoryById))]
	public ActionResult<HistoryToGet> GetHistoryById([FromRoute] uint historyId)
	{
		var history = historyService.GetById(historyId);
		if (history is null)
			return NotFound();
		var historyToGet = mapper.Map<HistoryToGet>(history);
		return Ok(historyToGet);
	}

	[HttpGet(Name = nameof(GetAllHistories))]
	public ActionResult<IEnumerable<HistoryToGet>> GetAllHistories()
	{
		var histories = historyService.GetAll();
		return Ok(histories.Select(mapper.Map<HistoryToGet>));
	}

	[HttpPost(Name = nameof(CreateHistory))]
	public async Task<IActionResult> CreateHistory([FromBody] HistoryToPost historyToPost)
	{
		if (historyToPost is null)
			return BadRequest("History is empty");
		if (!ModelState.IsValid)
			return UnprocessableEntity();
		var history = mapper.Map<History>(historyToPost);
		var createdHistory = await historyService.AddAsync(history);
		return CreatedAtRoute(nameof(GetHistoryById), new { historyId = createdHistory.Id }, createdHistory.Id);
	}

	[HttpPatch("{historyId:uint}", Name = nameof(UpdateHistory))]
	public async Task<IActionResult> UpdateHistory(uint historyId, [FromBody] HistoryToPatch historyToPatch)
	{
		var history = mapper.Map<History>(historyToPatch);
		history.Id = historyId;
		await historyService.UpdateAsync(history);
		return Ok();
	}

	[HttpDelete("{historyId:uint}", Name = nameof(DeleteHistory))]
	public async Task<IActionResult> DeleteHistory(uint historyId)
	{
		await historyService.DeleteAsync(historyService.GetById(historyId));
		return Ok();
	}
}
