using EduCore.Domain.Entities;

namespace EduCore.Application.Features.Sections.Queries.GetCourseSectionsPaginatedList;

public class GetCourseSectionsPaginatedListResponse
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public int Order { get; set; }
    public Guid CourseId { get; set; }
    public Course Course { get; set; }

    public GetCourseSectionsPaginatedListResponse(Guid id, string title, int order, Guid courseId)
    {
        Id = id;
        Title = title;
        Order = order;
        CourseId = courseId;
    }
}
