namespace EduCore.Application.Features.Feedback.Queries.GetCourseFeedbackPaginatedList;

public class GetCourseFeedbackPaginatedListResponse
{
    public Guid UserId { get; set; }
    public string UserName { get; set; }
    public int Rating { get; set; }
    public string? Comment { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}
