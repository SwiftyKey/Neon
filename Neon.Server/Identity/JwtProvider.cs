using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Neon.Application.Contracts;
using Neon.Domain.Entities;

namespace Neon.Server.Identity;

public class JwtProvider(IOptions<JwtOptions> options) : IJwtProvider
{
	private readonly JwtOptions _options = options.Value;
	public string GenerateToken(User user)
	{
		Claim[] userClaims = [new("user", user.Id.ToString())];

		var signingCredentials = new SigningCredentials
		(
			new SymmetricSecurityKey
			(
				Encoding.UTF8.GetBytes(_options.SecretKey)
			),
			SecurityAlgorithms.HmacSha256);

		var token = new JwtSecurityToken
		(
			claims: userClaims,
			signingCredentials: signingCredentials,
			expires: DateTime.Now.AddHours(_options.ExpiersHours)
		);

		var tokenValue = new JwtSecurityTokenHandler().WriteToken(token);

		return tokenValue;

	}
}
