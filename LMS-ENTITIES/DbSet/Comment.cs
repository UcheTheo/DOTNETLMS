namespace LMS_ENTITIES.DbSet;

public class Comment : BaseEntity
{
	public string Body { get; set; }

	// Relationships
	public List<Reply> Reply { get; set; } = new List<Reply>();

	public Guid UserId { get; set; }
	public User User { get; set; } = null!;

	public Guid CourseDataId { get; set; }
	public CourseData? CourseDetails { get; set; } = null!;
}
