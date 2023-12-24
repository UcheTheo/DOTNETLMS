namespace LMS_ENTITIES.DbSet;

public class UserCourse : BaseEntity
{
	public Guid UserId { get; set; }
	public Guid CourseId { get; set; }
}
