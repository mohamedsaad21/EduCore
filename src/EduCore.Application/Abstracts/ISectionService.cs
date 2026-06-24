using EduCore.Domain.Entities;
using EduCore.Domain.Enums;

namespace EduCore.Application.Abstracts;

public interface ISectionService
{
    IQueryable<Section> GetCourseSectionsPaginatedList(Guid CourseId, SectionOrderingEnum OrderBy, string? Search);
    Task<Section> GetByIdAsync(Guid? Id);
    Task<bool> IsSectionOrderExists(Guid CourseId, int Order);
    Task<bool> IsSectionTitleExists(Guid CourseId, string Title);
}
