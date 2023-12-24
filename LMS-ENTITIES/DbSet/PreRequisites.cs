namespace LMS_ENTITIES.DbSet;

public class PreRequisites : BaseEntity
{
	public string Title { get; set; }

	//Relationships
	public Guid CourseId { get; set; }

	public Course Course { get; set; } = null!;
}
