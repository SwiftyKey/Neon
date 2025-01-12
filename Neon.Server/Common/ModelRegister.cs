using Mapster;
using Neon.Application.ViewModels;
using Neon.Domain.Entities;
using Neon.Server.RequestEntities.Category;
using Neon.Server.RequestEntities.Manufacturer;
using Neon.Server.RequestEntities.Order;
using Neon.Server.RequestEntities.OrderComposition;
using Neon.Server.RequestEntities.Product;
using Neon.Server.RequestEntities.User;

namespace Neon.Server.Common;

public class ModelRegister : IRegister
{
	public void Register(TypeAdapterConfig config)
	{
		config.NewConfig<UserVm, UserToAuthorize>()
		.TwoWays()
		.Map(dest => dest.Login, src => src.Name)
		.Map(dest => dest.Password, src => src.Password);

		config.NewConfig<Product, ProductToGet>()
		.TwoWays()
		.Map(dest => dest.Name, src => src.Name)
		.Map(dest => dest.Description, src => src.Description)
		.Map(dest => dest.Cost, src => src.Cost)
		.Map(dest => dest.Count, src => src.Count)
		.Map(dest => dest.ImagePath, src => src.ImagePath)
		.Map(dest => dest.Category, src => src.Category.Title)
		.Map(dest => dest.Manufacturer, src => src.Manufacturer.Name)
		.Map(dest => dest.UpdatedAt, src => src.UpdatedAt)
		.Map(dest => dest.CreatedAt, src => src.CreatedAt);

		config.NewConfig<User, UserToGet>()
		.TwoWays()
		.Map(dest => dest.Name, src => src.Name)
		.Map(dest => dest.IsAdmin, src => src.IsAdmin)
		.Map(dest => dest.Orders, src => src.Orders)
		.Map(dest => dest.Products, src => src.Products)
		.Map(dest => dest.UpdatedAt, src => src.UpdatedAt)
		.Map(dest => dest.CreatedAt, src => src.CreatedAt);

		config.NewConfig<Category, CategoryToGet>()
		.TwoWays()
		.Map(dest => dest.Title, src => src.Title)
		.Map(dest => dest.Products, src => src.Products)
		.Map(dest => dest.UpdatedAt, src => src.UpdatedAt)
		.Map(dest => dest.CreatedAt, src => src.CreatedAt);

		config.NewConfig<Manufacturer, ManufacturerToGet>()
		.TwoWays()
		.Map(dest => dest.Name, src => src.Name)
		.Map(dest => dest.Products, src => src.Products)
		.Map(dest => dest.UpdatedAt, src => src.UpdatedAt)
		.Map(dest => dest.CreatedAt, src => src.CreatedAt);

		config.NewConfig<Order, OrderToGet>()
		.TwoWays()
		.Map(dest => dest.Title, src => src.Title)
		.Map(dest => dest.UserId, src => src.UserId)
		.Map(dest => dest.Bought, src => src.Bought)
		.Map(dest => dest.Compositions, src => src.Compositions)
		.Map(dest => dest.UpdatedAt, src => src.UpdatedAt)
		.Map(dest => dest.CreatedAt, src => src.CreatedAt);

		config.NewConfig<OrderComposition, OrderCompositionToGet>()
		.TwoWays()
		.Map(dest => dest.Count, src => src.Count)
		.Map(dest => dest.Product, src => src.Product)
		.Map(dest => dest.Order, src => src.Order)
		.Map(dest => dest.UpdatedAt, src => src.UpdatedAt)
		.Map(dest => dest.CreatedAt, src => src.CreatedAt);
	}
}