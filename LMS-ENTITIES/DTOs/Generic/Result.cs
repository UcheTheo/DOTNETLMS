using LMS_ENTITIES.DTOs.Errors;

namespace LMS_ENTITIES.DTOs.Generic;

public class Result<T>
{
	public T Content { get; set; }
	public Error Error { get; set; }
	public bool IsSuccess { get; set; }	
	public DateTime ResponseTime { get; set; } = DateTime.UtcNow;
}
