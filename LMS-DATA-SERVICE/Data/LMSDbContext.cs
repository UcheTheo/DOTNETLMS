using System.Reflection.Emit;
using LMS_ENTITIES.DbSet;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LMS_DATA_SERVICE.Data;

public class LMSDbContext : IdentityDbContext
{
	public DbSet<User> Users { get; set; }
	public DbSet<Avatar> Avatars { get; set; }
	public DbSet<Course> Courses { get; set; }
	public DbSet<PublicImage> PublicImages { get; set; }
	public DbSet<CourseData> CourseDatas { get; set; }
	public DbSet<Link> Links { get; set; }
	public DbSet<Comment> Comments { get; set; }
	public DbSet<Benefit> Benefits { get; set; }
	public DbSet<PreRequisites> Prerequisites { get; set; }
	public DbSet<Reply> Relies { get; set; }
	public DbSet<Review> Reviews { get; set; }
	public DbSet<UserCourse> UserCourses { get; set; }

	public LMSDbContext(DbContextOptions<LMSDbContext> options) : base(options)
	{
	}

	protected override void OnModelCreating(ModelBuilder builder)
	{
		base.OnModelCreating(builder);
		//----------------------------------------------------------------------------------------

		//-------USER-------------
		//Configure User-Course many-to-many relationship
		builder.Entity<User>()
		.HasMany(u => u.Courses)
		.WithMany(c => c.Users)
		.UsingEntity<UserCourse>();

		// Configure User-Avatar one-to-one relationship
		builder.Entity<User>()
			.HasOne(u => u.Avatar)
			.WithOne(a => a.User)
			.HasForeignKey<Avatar>(a => a.UserId)
			.IsRequired();

		// Configure User-Comment one-to-many relationship
		builder.Entity<User>()
			.HasMany(u => u.Comments)
			.WithOne(c => c.User)
			.HasForeignKey(c => c.UserId)
			.IsRequired();

		// Configure User-Reply one-to-many relationship
		builder.Entity<User>()
			.HasMany(u => u.Replys)
			.WithOne(r => r.User)
			.HasForeignKey(r => r.UserId)
			.IsRequired();

		// Configure User-Review one-to-many relationship
		builder.Entity<User>()
			.HasMany(u => u.Reviews)
			.WithOne(r => r.User)
			.HasForeignKey(r => r.UserId)
			.IsRequired();
//----------------------------------------------------------------------------------------

		//-------COURSE-------------
		// Configure Course-PublicImage one-to-one relationship
		builder.Entity<Course>()
			.HasOne(c => c.ThumbNail)
			.WithOne(t => t.Course)
			.HasForeignKey<PublicImage>(t => t.CourseId)
			.IsRequired();

		// Configure Course-CourseData one-to-one relationship
		builder.Entity<Course>()
			.HasOne(c => c.CourseDetails)
			.WithOne(d => d.Course)
			.HasForeignKey<CourseData>(d => d.CourseId)
			.IsRequired();

		// Configure Course-Review one-to-many relationship
		builder.Entity<Course>()
			.HasMany(c => c.Reviews)
			.WithOne(r => r.Course)
			.HasForeignKey(r => r.CourseId)
			.IsRequired();

		// Configure Course-Prerequisites one-to-many relationship
		builder.Entity<Course>()
			.HasMany(c => c.Prerequisites)
			.WithOne(p => p.Course)
			.HasForeignKey(p => p.CourseId)
			.IsRequired();

		// Configure Course-Benefits one-to-many relationship
		builder.Entity<Course>()
			.HasMany(c => c.Benefits)
			.WithOne(b => b.Course)
			.HasForeignKey(b => b.CourseId)
			.IsRequired();

		builder.Entity<Course>()
		.Property(c => c.Rating)
		.HasDefaultValue(0);

		builder.Entity<Course>()
		.Property(c => c.RatingsQuantity)
		.HasDefaultValue(0);

		builder.Entity<Course>()
		.Property(c => c.Purchased)
		.HasDefaultValue(0);

		builder.Entity<Course>()
		.Property(c => c.RatingsAverage)
		.HasDefaultValue(4.5);
//------------------------------------------------------------------------------------------

		//-------COURSEDATA-------------
		// Configure CourseData-Link one-to-many relationship
		builder.Entity<CourseData>()
			.HasMany(d => d.Links)
			.WithOne(l => l.CourseDetail)
			.HasForeignKey(l => l.CourseDataId)
			.IsRequired();

		// Configure CourseData-Comment one-to-many relationship
		builder.Entity<CourseData>()
			.HasMany(d => d.Comments)
			.WithOne(c => c.CourseDetails)
			.HasForeignKey(c => c.CourseDataId)
			.IsRequired();
//---------------------------------------------------------------------------------------------

		//-------COMMENT-------------
		// Configure Comment-Reply one-to-many relationship
		builder.Entity<Comment>()
			.HasMany(c => c.Reply)
			.WithOne(r => r.Comment)
			.HasForeignKey(r => r.CommentId)
			.IsRequired(false);
//---------------------------------------------------------------------------------------------

		//-------REVIEW-------------
		// Ensure unique constraint for the combination of UserId and CourseId
		builder.Entity<Review>()
			.HasIndex(r => new { r.UserId, r.CourseId })
			.IsUnique();

		// Configure Review-Reply one-to-many relationship
		builder.Entity<Review>()
			.HasMany(r => r.Reply)
			.WithOne(p => p.Review)
			.HasForeignKey(p => p.ReviewId)
			.IsRequired(false);
//----------------------------------------------------------------------------------------------

		builder.Entity<Reply>()
			.ToTable(table => table.HasCheckConstraint("CK_Reply_EitherCommentOrReview",
					"([CommentId] IS NOT NULL AND [ReviewId] IS NULL) OR ([CommentId] IS NULL AND [ReviewId] IS NOT NULL)"));

		builder.Entity<Course>()
			.Property(c => c.EstimatedPrice)
			.HasColumnType("decimal(18, 2)");

		builder.Entity<Course>()
			.Property(c => c.Price)
			.HasPrecision(18, 2);
	}
}






	

