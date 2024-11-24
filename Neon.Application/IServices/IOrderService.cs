﻿using Neon.Domain.Entities;

namespace Neon.Application.IServices;

public interface IOrderService
{
	Task<Order> AddAsync(Order model);
	Task UpdateAsync(Order model);
	Task DeleteAsync(Order model);
	IEnumerable<Order> GetAll();
	Order GetById(uint id);
	Order? GetByTitle(string title);
}
