﻿namespace Neon.Domain.Base;

public abstract class BaseAuditableEntity : BaseEntity
{
	public DateTimeOffset CreatedAt { get; set; }
	public DateTimeOffset UpdatedAt { get; set; }
}