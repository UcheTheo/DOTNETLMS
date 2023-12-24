namespace LMS_ENTITIES.DbSet;

public class Review : BaseEntity
{
	public int Rating { get; set; }
	public string Content { get; set; }

	// Relationships
	public List<Reply> Reply { get; set; } = new List<Reply>();

	public Guid UserId { get; set; }
	public User User { get; set; } = null!;

	public Guid CourseId { get; set; }
	public Course Course { get; set;} = null!;


}
