namespace EduCore.Core.Features.Courses.Queries.GetCoursesByCategoryIdPaginatedList;

public class GetCoursesByCategoryIdPaginatedListResponse
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Thumbnail { get; set; }
    public decimal Price { get; set; }
    public int DiscountPercentage { get; set; }
    public string Status { get; set; }
    public string InstructorName { get; set; }
    public string InstructorProfilePictureUrl { get; set; }
    public double? AverageRating { get; set; }
    public int? RatingCount { get; set; }
    public int? NoOfStudents { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    public GetCoursesByCategoryIdPaginatedListResponse(Guid id, string title, string description, string thumbnail, decimal price, string status, string instructorName, string instructorProfilePictureUrl, DateTime createdAt, double? averageRating = null
        , int? ratingCount = null, int? noOfStudents = null, DateTime? updatedAt = null)
    {
        Id = id;
        Title = title;
        Description = description;
        Thumbnail = thumbnail;
        Price = price;
        Status = status;
        InstructorName = instructorName;
        InstructorProfilePictureUrl = instructorProfilePictureUrl;
        AverageRating = averageRating;
        RatingCount = ratingCount;
        NoOfStudents = noOfStudents;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }
}

