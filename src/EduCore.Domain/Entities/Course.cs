using EduCore.Domain.Entities.Identity;
using EduCore.Domain.Enums;

namespace EduCore.Domain.Entities;

public class Course : DatedEntity
{
    public Course()
    {
        Sections = new HashSet<Section>();
        Feedbacks = new HashSet<Feedback>();
    }
    public string Title { get; set; }
    public string Description { get; set; }
    public string? ThumbnailUrl { get; set; }
    public string? ThumbnailPublicId { get; set; }
    public decimal Price { get; set; }
    public int DiscountPercentage { get; set; }
    public CourseStatus Status { get; set; } = CourseStatus.Pending;
    public int? TotalHours { get; set; }
    public double? AverageRating { get; set; }
    public int? RatingCount  { get; set; }
    public int? NoOfStudents  { get; set; }
    public Guid CategoryId { get; set; }
    public Guid InstructorId { get; set; }
    public CourseCategory Category { get; set; }
    public ICollection<Section> Sections { get; set; }
    public User Instructor { get; set; }
    public ICollection<Feedback> Feedbacks { get; set; }
}
