﻿using Neon.Domain.Base;

namespace Neon.Domain.Entities;

public class OrderComposition: BaseEntity
{
	public uint Count { get; set; }

	public int OrderId { get; set; }
	public Order? Order { get; set; }

	public int ProductId { get; set; }
	public Product? Product { get; set; }
}
