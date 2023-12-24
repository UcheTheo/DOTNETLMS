using System.Security;

namespace LMS_ENTITIES.DbSet;

public class Link : BaseEntity
{
	public string Title { get; set; }
	public string Url { get; set; }

	// Relationships
	public Guid CourseDataId { get; set; }
	public CourseData CourseDetail { get; set; } = null!;
}
