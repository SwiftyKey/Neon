using Mapster;
using MapsterMapper;

namespace Neon.Server.Extensions;

public static class MapperExtension
{
	public static IServiceCollection RegisterMapster(this IServiceCollection services)
	{
		var config = TypeAdapterConfig.GlobalSettings;
		config.Default.IgnoreNullValues(true);
		services.AddSingleton(config);
		services.AddScoped<IMapper, Mapper>();
		return services;
	}
}
