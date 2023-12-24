namespace LMS_ENTITIES.DbSet;

public class PublicImage : BaseEntity
{
	public string PublicId { get; set; }
	public string Url { get; set; }

	public Guid CourseId { get; set; } // Foreign key for the course
	public Course Course { get; set; } // Navigation property back to course
}
