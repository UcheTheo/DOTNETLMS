using System.ComponentModel.DataAnnotations;

namespace LMS_ENTITIES.DbSet;

public class Course : BaseEntity
{
	public string Name { get; set; }
	public string Description { get; set; }
	public decimal Price { get; set; }
	public decimal EstimatedPrice { get; set; }
	public string? Tags { get; set; }
	public string? Level { get; set; }
	public string DemoUrl { get; set; }
	public int Rating { get; set; }
	public int Purchased { get; set; }

	[Range(1, 5, ErrorMessage ="Ratings Average must be between 1 and 5")]
	public int RatingsAverage { get; set; }
	public int RatingsQuantity { get; set; }
	public double? PriceDiscount { get; set; }

	// Relationships
	public List<Benefit> Benefits { get; set; } = new List<Benefit>();
	public List<PreRequisites> Prerequisites { get; set; } = new List<PreRequisites>();
	public List<Review> Reviews { get; set; } = new();
	public CourseData? CourseDetails { get; set; }
	public PublicImage? ThumbNail { get; set; }
	public List<User> Users { get;} = new();
}
