﻿using Neon.Server.RequestEntities.History;
using Neon.Server.RequestEntities.Order;

namespace Neon.Server.RequestEntities.User;

public class UserToGet
{
	public int Id { get; set; }
	public string Name { get; set; }
	public bool IsAdmin { get; set; }
	public ICollection<OrderToGet> Orders { get; set; } = [];
	public ICollection<HistoryToGet> History { get; set; } = [];
	public DateTimeOffset CreatedAt { get; set; }
	public DateTimeOffset UpdatedAt { get; set; }
}
