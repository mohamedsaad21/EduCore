using EduCore.Domain.Entities;

namespace EduCore.Application.Features.Courses.Queries.GetCourseById;

public class GetCourseByIdResponse
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Thumbnail { get; set; }
    public decimal Price { get; set; }
    public int DiscountPercentage { get; set; }
    public string Status { get; set; }
    public double? AverageRating { get; set; }
    public int? RatingCount { get; set; }
    public int? NoOfStudents { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string InstructorName { get; set; }
    public string InstructorProfilePictureUrl { get; set; }
    public Guid CategoryId { get; set; }
    public CourseCategory Category { get; set; }
}
