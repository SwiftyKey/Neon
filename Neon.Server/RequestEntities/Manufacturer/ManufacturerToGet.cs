﻿using Neon.Server.RequestEntities.Product;

namespace Neon.Server.RequestEntities.Manufacturer;

public class ManufacturerToGet
{
	public int Id { get; set; }
	public string Name { get; set; }
	public ICollection<ProductToGet> Products { get; set; } = [];
	public DateTimeOffset CreatedAt { get; set; }
	public DateTimeOffset UpdatedAt { get; set; }
}
