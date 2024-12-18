using Neon.Application.Contracts;
using Neon.Server.Identity;

namespace Neon.Server.Extensions;

public static class ConifgurationIdentityService
{
	public static IServiceCollection ConfigureIdentityService(this IServiceCollection services)
	{
		services.AddScoped<IJwtProvider, JwtProvider>();
		return services;
	}
}
