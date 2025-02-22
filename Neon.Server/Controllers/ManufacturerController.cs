﻿using MapsterMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Neon.Application.IServices;
using Neon.Domain.Entities;
using Neon.Server.RequestEntities.Manufacturer;

namespace Neon.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class ManufacturerController(IManufacturerService manufacturerService, IMapper mapper) : ControllerBase
{
	[HttpGet("{manufacturerId:int}", Name = nameof(GetManufacturerById))]
	public ActionResult<ManufacturerToGet> GetManufacturerById([FromRoute] int manufacturerId)
	{
		var manufacturer = manufacturerService.GetById(manufacturerId);
		if (manufacturer is null)
			return NotFound();
		var manufacturerToGet = mapper.Map<ManufacturerToGet>(manufacturer);
		return Ok(manufacturerToGet);
	}

	[HttpGet("{name}", Name = nameof(GetManufacturerByName))]
	public ActionResult<ManufacturerToGet> GetManufacturerByName([FromRoute] string name)
	{
		var manufacturer = manufacturerService.GetByName(name);
		if (manufacturer is null)
			return NotFound();
		var manufacturerToGet = mapper.Map<ManufacturerToGet>(manufacturer);
		return Ok(manufacturerToGet);
	}

	[HttpGet(Name = nameof(GetAllManufacturers))]
	public ActionResult<IEnumerable<ManufacturerToGet>> GetAllManufacturers()
	{
		var manufacturers = manufacturerService.GetAll();
		return Ok(manufacturers.Select(mapper.Map<ManufacturerToGet>));
	}

	[HttpPost(Name = nameof(CreateManufacturer))]
	[Authorize(Policy = "AdminPolicy")]
	public async Task<IActionResult> CreateManufacturer([FromBody] ManufacturerToPost manufacturerToPost)
	{
		if (manufacturerToPost is null)
			return BadRequest("Manufacturer is empty");
		if (!ModelState.IsValid)
			return UnprocessableEntity();
		var manufacturer = mapper.Map<Manufacturer>(manufacturerToPost);
		var createdManufacturer = await manufacturerService.AddAsync(manufacturer);
		return CreatedAtRoute(nameof(GetManufacturerById), new { manufacturerId = createdManufacturer.Id }, createdManufacturer.Id);
	}

	[HttpPatch("{manufacturerId:int}", Name = nameof(UpdateManufacturer))]
	[Authorize(Policy = "AdminPolicy")]
	public async Task<IActionResult> UpdateManufacturer(int manufacturerId, [FromBody] ManufacturerToPatch manufacturerToPatch)
	{
		var manufacturer = mapper.Map<Manufacturer>(manufacturerToPatch);
		manufacturer.Id = manufacturerId;
		await manufacturerService.UpdateAsync(manufacturer);
		return Ok();
	}

	[HttpDelete("{manufacturerId:int}", Name = nameof(DeleteManufacturer))]
	[Authorize(Policy = "AdminPolicy")]
	public async Task<IActionResult> DeleteManufacturer(int manufacturerId)
	{
		await manufacturerService.DeleteAsync(manufacturerService.GetById(manufacturerId));
		return Ok();
	}
}
