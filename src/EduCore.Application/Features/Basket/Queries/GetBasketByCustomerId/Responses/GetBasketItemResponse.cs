namespace EduCore.Application.Features.Basket.Queries.GetBasketByCustomerId.Responses;

public class GetBasketItemResponse
{
    public Guid Id { get; set; }
    public Guid CartId { get; set; }
    public Guid CourseId { get; set; }
    public string CourseTitle { get; set; }
    public string CourseThumbnailUrl { get; set; }
    public string InstructorName { get; set; }
    public string InstructorProfilePictureUrl { get; set; }
    public double AverageRating { get; set; }
    public int TotalHours { get; set; }
    public int NoOfLectures { get; set; }
    public string Category { get; set; }
    public decimal BasePrice { get; set; }
    public decimal Discount { get; set; }
    public decimal TotalPrice { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}
