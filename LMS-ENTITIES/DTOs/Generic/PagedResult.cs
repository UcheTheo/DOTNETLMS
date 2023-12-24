namespace LMS_ENTITIES.DTOs.Generic;

public class PagedResult<T> : Result<List<T>>
{
	public int Page { get; set; }
	public int ResultCount { get; set; }
	public int Results { get; set; }
}
