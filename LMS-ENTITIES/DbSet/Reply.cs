namespace LMS_ENTITIES.DbSet;

public class Reply : BaseEntity
{
	public string Content { get; set; }

	// Relationships
	public Guid UserId { get; set; }
	public User User { get; set; } = null!;

	public Guid? CommentId { get; set; }
	public Comment? Comment { get; set; } 

	public Guid? ReviewId { get; set; }
	public Review? Review { get; set; }
}
