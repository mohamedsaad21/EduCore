namespace EduCore.Application.Features.CourseProgress.Queries.GetCourseProgress;

public class GetCourseProgressResponse
{
    public int TotalContent { get; set; }
    public int TotalCompleted { get; set; }
    public double Percent { get; set; }
}
