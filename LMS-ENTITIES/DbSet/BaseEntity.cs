﻿namespace LMS_ENTITIES.DbSet;

public abstract class BaseEntity
{	
	public Guid Id { get; set; } = Guid.NewGuid();
	public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
	public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}