using EduCore.Core.Features.Courses.Queries.GetCoursePaginatedList;
using EduCore.Domain.Entities;

namespace EduCore.Core.Features.Courses.Queries.GetCoursesByInstructorIdPaginatedList;

public class GetCoursesByInstructorIdPaginatedListResponse
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
    public virtual CategoryResponse Category { get; set; }

    public GetCoursesByInstructorIdPaginatedListResponse(Guid id, string title, string description, string thumbnail, decimal price, string status, DateTime createdAt, Guid categoryId, string instructorName, string instructorProfilePictureUrl,double? averageRating = null
        , int? ratingCount = null, int? noOfStudents = null, DateTime? updatedAt = null, CourseCategory? category = null)
    {
        Id = id;
        Title = title;
        Description = description;
        Thumbnail = thumbnail;
        Price = price;
        Status = status;
        AverageRating = averageRating;
        RatingCount = ratingCount;
        NoOfStudents = noOfStudents;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
        CategoryId = categoryId;
        InstructorName = instructorName;
        InstructorProfilePictureUrl = instructorProfilePictureUrl;
        Category = category == null ? null : new CategoryResponse { Id = category.Id, Name = category.Localize(category.NameAr, category.NameEn) };
    }
}
