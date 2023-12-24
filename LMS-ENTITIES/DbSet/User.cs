namespace LMS_ENTITIES.DbSet;

public class User : BaseEntity
{
	public Guid IdentityId { get; set; }
	public string Name { get; set; }
	public string Email { get; set; }
	public string Password { get; set; }
	public bool IsVerified { get; set; } = false;
	public bool IsActive { get; set; } = true;
	public string? PasswordResetToken { get; set; }
	public DateTime? PasswordChangedAt { get; set; }
	public DateTime? PasswordResetExpiresAt { get;set; }

	// Relationships
	public Avatar Avatar { get; set; }

	public List<Comment> Comments { get; set; } = new List<Comment>();

	public List<Reply> Replys { get; set; } = new List<Reply>();

	public List<Review> Reviews { get; set; } = new List<Review>();

	public List<Course> Courses { get; } = new();
}
