namespace EduCore.Application.Features.Enrollments.Queries.GetUserEnrollmentsPaginatedList;

public class GetUserEnrollmentsPaginatedListResponse
{
    public Guid UserId { get; set; }
    public Guid CourseId { get; set; }
    public string Title { get; set; }
    public string Thumbnail { get; set; }
    public string InstructorName { get; set; }
    public int? TotalHours { get; set; }
    public int ProgressPercent { get; set; }
    public DateTime EnrolledAt { get; set; }
}
