﻿using MapsterMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Neon.Application.IServices;
using Neon.Application.ViewModels;
using Neon.Server.RequestEntities.User;

namespace Neon.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class UserController(IUserService userService, IMapper mapper) : Controller
{
	[HttpGet("{userId:int}", Name = nameof(GetUserById))]
	public ActionResult<UserToGet> GetUserById([FromRoute] int userId)
	{
		var user = userService.GetById(userId);
		if (user is null)
			return NotFound();
		var userToGet = mapper.Map<UserToGet>(user);
		return Ok(userToGet);
	}

	[HttpGet("{name}", Name = nameof(GetUserByName))]
	public ActionResult<UserToGet> GetUserByName([FromRoute] string name)
	{
		var user = userService.GetByName(name);
		if (user is null)
			return NotFound();
		var userToGet = mapper.Map<UserToGet>(user);
		return Ok(userToGet);
	}

	[HttpGet(Name = nameof(GetAllUsers))]
	public ActionResult<IEnumerable<UserToGet>> GetAllUsers()
	{
		var users = userService.GetAll();
		return Ok(users.Select(mapper.Map<UserToGet>));
	}

	[HttpPost(Name = nameof(CreateUser))]
	public async Task<IActionResult> CreateUser([FromBody] UserToPost userToPost)
	{
		if (userToPost is null)
			return BadRequest("User is empty");
		if (!ModelState.IsValid)
			return UnprocessableEntity();
		var user = mapper.Map<UserVm>(userToPost);
		var createdUser = await userService.AddAsync(user);
		return CreatedAtRoute(nameof(GetUserById), new { userId = createdUser.Id }, createdUser.Id);
	}

	[HttpPatch("{userId:int}", Name = nameof(UpdateUser))]
	[Authorize(Policy = "AdminPolicy")]
	public async Task<IActionResult> UpdateUser(int userId, [FromBody] UserToPatch userToPatch)
	{
		var user = mapper.Map<UserVm>(userToPatch);
		user.Id = userId;
		await userService.UpdateAsync(user);
		return Ok();
	}

	[HttpDelete("{userId:int}", Name = nameof(DeleteUser))]
	[Authorize(Policy = "AdminPolicy")]
	public async Task<IActionResult> DeleteUser(int userId)
	{
		await userService.DeleteAsync(new UserVm { Id = userId });
		return Ok();
	}

	[HttpPost("ChangeRights")]
	[Authorize(Policy = "AdminPolicy")]
	public async Task<IActionResult> ChangeRights([FromQuery] UserChangeRights userChangeRights)
	{
		await userService.ChangeRights(userChangeRights.IsAdmin, userChangeRights.UserId);
		return Ok();
	}
}
