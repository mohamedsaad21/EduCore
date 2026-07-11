namespace EduCore.Core.Features.Courses.Queries.GetCoursePaginatedList;

public class GetCoursePaginatedListResponse
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string ThumbnailUrl { get; set; }
    public decimal Price { get; set; }
    public int DiscountPercentage { get; set; }
    public string Status { get; set; }
    public double? AverageRating { get; set; }
    public int? RatingCount { get; set; }
    public int? NoOfStudents { get; set; }
    public int? NoOfSections { get; set; }
    public int? NoOfLectures { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string InstructorName { get; set; }
    public string InstructorProfilePictureUrl { get; set; }
    public Guid CategoryId { get; set; }
    public virtual CategoryResponse Category { get; set; }
}
