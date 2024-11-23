using Microsoft.Extensions.DependencyInjection;
using Neon.Application.IRepositories;
using Neon.Infrastructure.Repositories;

namespace Neon.Infrastructure.Extensions;

public static class RepositoriesExtension
{
	public static void AddRepositories(this IServiceCollection collection)
	{
		collection.AddScoped<ICategoryRepository, CategoryRepository>();
		collection.AddScoped<IManufacturerRepository, ManufacturerRepository>();
		collection.AddScoped<IOrderRepository, OrderRepository>();
		collection.AddScoped<IProductRepository, ProductRepository>();
		collection.AddScoped<IUserRepository, UserRepository>();
	}
}
