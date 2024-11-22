﻿using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using Neon.Application.IServices;
using Neon.Domain.Entities;
using Neon.Server.RequestEntities.Category;

namespace Neon.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryController(ICategoryService categoryService, IMapper mapper) : ControllerBase
{
	[HttpGet("{categoryid:uint}", Name = nameof(GetCategoryById))]
	public ActionResult<CategoryToGet> GetCategoryById([FromRoute] uint categoryid)
	{
		var category = categoryService.GetById(categoryid);
		if (category is null)
			return NotFound();
		var categoryToGet = mapper.Map<CategoryToGet>(category);
		return Ok(categoryToGet);
	}

	[HttpGet("{title:string}", Name = nameof(GetCategoryByTitle))]
	public ActionResult<CategoryToGet> GetCategoryByTitle([FromRoute] string title)
	{
		var category = categoryService.GetByTitle(title);
		if (category is null)
			return NotFound();
		var categoryToGet = mapper.Map<CategoryToGet>(category);
		return Ok(categoryToGet);
	}

	[HttpGet(Name = nameof(GetAllCategories))]
	public ActionResult<IEnumerable<CategoryToGet>> GetAllCategories()
	{
		var categories = categoryService.GetAll();
		return Ok(categories.Select(mapper.Map<CategoryToGet>));
	}

	[HttpPost(Name = nameof(CreateCategory))]
	public async Task<IActionResult> CreateCategory([FromBody] CategoryToPost categoryToPost)
	{
		if (categoryToPost is null)
			return BadRequest("Category is empty");
		if (!ModelState.IsValid)
			return UnprocessableEntity();
		var category = mapper.Map<Category>(categoryToPost);
		var createdCategory = await categoryService.AddAsync(category);
		return CreatedAtRoute(nameof(GetCategoryById), new { categoryid = createdCategory.Id }, createdCategory.Id);
	}

	[HttpPatch("{categoryid:uint}", Name = nameof(UpdateCategory))]
	public async Task<IActionResult> UpdateCategory(uint categoryid, [FromBody] CategoryToPatch categoryToPatch)
	{
		var category = mapper.Map<Category>(categoryToPatch);
		category.Id = categoryid;
		await categoryService.UpdateAsync(category);
		return Ok();
	}

	[HttpDelete("{categoryid:uint}", Name = nameof(DeleteCategory))]
	public async Task<IActionResult> DeleteCategory(uint categoryid)
	{
		await categoryService.DeleteAsync(categoryService.GetById(categoryid));
		return Ok();
	}
}
