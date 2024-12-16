using System.Reflection;
using Mapster;
using MapsterMapper;
using Neon.Server.Common;

namespace Neon.Server.Extensions;

public static class MapperExtension
{
	public static IServiceCollection RegisterMapster(this IServiceCollection services)
	{
		var config = TypeAdapterConfig.GlobalSettings;
		config.Default.IgnoreNullValues(true);
		var registers = config.Scan(Assembly.GetAssembly(typeof(ModelRegister)));
		config.Apply(registers);
		services.AddSingleton(config);
		services.AddScoped<IMapper, Mapper>();
		return services;
	}
}