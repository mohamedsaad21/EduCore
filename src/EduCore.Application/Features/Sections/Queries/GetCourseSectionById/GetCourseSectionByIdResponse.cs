using EduCore.Domain.Entities;

namespace EduCore.Application.Features.Sections.Queries.GetCourseSectionById;

public class GetCourseSectionByIdResponse
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int Order { get; set; }
    public int CourseId { get; set; }
    public Course Course { get; set; }
}
