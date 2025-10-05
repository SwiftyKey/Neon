using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using Neon.Application.IServices;
using Neon.Application.ViewModels;
using Neon.Server.RequestEntities;
using Neon.Server.RequestEntities.User;

namespace Neon.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController(IUserService userService, IMapper mapper) : Controller
{
	[HttpPost("Login")]
	public async Task<ActionResult<Token>> Login([FromBody] UserToAuthorize user)
	{
		var token = new Token { AccessToken = await userService.Login(mapper.Map<UserVm>(user)) };
		HttpContext.Response.Cookies.Append("access_token", token.AccessToken);
		return Ok(token);
	}

	[HttpPost("Registration")]
	public async Task<ActionResult> Registration([FromBody] UserToAuthorize userToAuthorize)
	{
		if (userToAuthorize is null)
			return BadRequest("User is empty");
		if (!ModelState.IsValid)
			return UnprocessableEntity();
		try
		{
			var user = mapper.Map<UserVm>(userToAuthorize);
			await userService.AddAsync(user);
			return Ok();
		}
		catch (Exception ex)
		{
			return BadRequest(ex.Message);
		}
	}
}
