namespace LMS_ENTITIES.DbSet;

public class Avatar : BaseEntity
{
	public string PublicId { get; set; }
	public string Url { get; set; }

	public Guid UserId { get; set; }
	public User User { get; set; }
}
