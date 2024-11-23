using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace Neon.Server.Extensions;

public static class AuthExtension
{
	public static IServiceCollection AddAuthentication(IServiceCollection services)
	{
		services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
			.AddJwtBearer(options =>
			{
				options.RequireHttpsMetadata = false;
				options.TokenValidationParameters = new TokenValidationParameters
				{
					ValidAudience = AuthOptions.Audience,
					ValidIssuer = AuthOptions.Issuer,
					IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey()
				};
			});

		return services.AddAuthorization();
	}
}