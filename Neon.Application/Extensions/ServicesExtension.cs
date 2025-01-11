using Microsoft.Extensions.DependencyInjection;
using Neon.Application.Base;
using Neon.Application.Hashers;
using Neon.Application.IServices;
using Neon.Application.Services;

namespace Neon.Application.Extensions;

public static class ServicesExtension
{
	public static void AddServices(this IServiceCollection collection, string productImagesPath)
	{
		collection.AddSingleton<IHasher, SHA256Hasher>();
		collection.AddScoped<ICategoryService, CategoryService>();
		collection.AddScoped<IManufacturerService, ManufacturerService>();
		collection.AddScoped<IOrderService, OrderService>();
		collection.AddScoped<IOrderCompositionService, OrderCompositionService>();
		collection.AddScoped<IProductService, ProductService>();
		collection.AddScoped<IUserService, UserService>();
		collection.AddScoped<IForecastingService, ForecastingService>();
		collection.AddScoped<IProductImageService>(x => new ProductImageService(productImagesPath));
	}

	public static void AddServices(this IServiceCollection collection)
	{
		collection.AddSingleton<IHasher, SHA256Hasher>();
		collection.AddScoped<ICategoryService, CategoryService>();
		collection.AddScoped<IManufacturerService, ManufacturerService>();
		collection.AddScoped<IOrderService, OrderService>();
		collection.AddScoped<IOrderCompositionService, OrderCompositionService>();
		collection.AddScoped<IProductService, ProductService>();
		collection.AddScoped<IUserService, UserService>();
		collection.AddScoped<IForecastingService, ForecastingService>();
	}
}
