namespace LMS_ENTITIES.DbSet;

public class CourseData : BaseEntity
{
	public string Title { get; set; }
	public string Description { get; set; }
	public string VideoUrl { get; set; }
	public string VideoSection { get; set; }
	public int? VideoLength { get; set; }
	public string VideoPlayer { get; set; }
	public string Suggestion { get; set; }


	// Relationships
	public List<Link> Links { get; set; } = new List<Link>();

	public List<Comment> Comments { get; set; } = new List<Comment>();

	public Guid CourseId { get; set; }
	public Course Course { get; set; }
}
