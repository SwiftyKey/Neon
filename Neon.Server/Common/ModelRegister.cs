using Mapster;
using Neon.Domain.Entities;
using Neon.Server.RequestEntities.Product;

namespace Neon.Server.Common;

public class ModelRegister : IRegister
{
	public void Register(TypeAdapterConfig config)
	{
		config.NewConfig<Product, ProductToGet>()
			.TwoWays()
			.Map(dest => dest.Name, src => src.Name)
			.Map(dest => dest.Description, src => src.Description)
			.Map(dest => dest.Cost, src => src.Cost)
			.Map(dest => dest.Count, src => src.Count)
			.Map(dest => dest.ImagePath, src => src.ImagePath)
			.Map(dest => dest.Category, src => src.Category.Title)
			.Map(dest => dest.Manufacturer, src => src.Manufacturer.Name);
	}
}