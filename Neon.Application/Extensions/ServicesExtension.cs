using Microsoft.Extensions.DependencyInjection;
using Neon.Application.Base;
using Neon.Application.Hashers;
using Neon.Application.IServices;
using Neon.Application.Services;
using Neon.Application.Validation;
using Neon.Application.ViewModels;

namespace Neon.Application.Extensions;

public static class ServicesExtension
{
	public static void AddServices(this IServiceCollection collection, string productImagesPath)
	{
		collection.AddSingleton<IHasher, SHA256Hasher>();
		collection.AddSingleton<IValidationHandler<UserVm>, NameValidator>();
		collection.AddSingleton<IValidationHandler<UserVm>, PasswordValidator>();
		collection.AddSingleton<UserValidationPipeline>();
		collection.AddScoped<ICategoryService, CategoryService>();
		collection.AddScoped<IManufacturerService, ManufacturerService>();
		collection.AddScoped<IOrderService, OrderService>();
		collection.AddScoped<IOrderCompositionService, OrderCompositionService>();
		collection.AddScoped<IProductService, ProductService>();
		collection.AddScoped<IUserService, UserService>();
		collection.AddScoped<IPaymentService, DummyPaymentService>();
		collection.AddScoped<IProductImageService>(x => new ProductImageService(productImagesPath));
	}

	public static void AddServices(this IServiceCollection collection)
	{
		collection.AddSingleton<IHasher, SHA256Hasher>();
		collection.AddSingleton<IValidationHandler<UserVm>, NameValidator>();
		collection.AddSingleton<IValidationHandler<UserVm>, PasswordValidator>();
		collection.AddSingleton<UserValidationPipeline>();
		collection.AddScoped<ICategoryService, CategoryService>();
		collection.AddScoped<IManufacturerService, ManufacturerService>();
		collection.AddScoped<IOrderService, OrderService>();
		collection.AddScoped<IOrderCompositionService, OrderCompositionService>();
		collection.AddScoped<IProductService, ProductService>();
		collection.AddScoped<IUserService, UserService>();
		collection.AddScoped<IPaymentService, DummyPaymentService>();
	}
}
