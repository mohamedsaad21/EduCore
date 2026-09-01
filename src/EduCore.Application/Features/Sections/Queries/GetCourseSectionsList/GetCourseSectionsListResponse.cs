namespace EduCore.Application.Features.Sections.Queries.GetCourseSectionsList;

public class GetCourseSectionsListResponse
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public int Order { get; set; }
    public int NoOfLectures { get; set; }
    public Guid CourseId { get; set; }
}
