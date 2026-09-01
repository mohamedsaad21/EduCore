using EduCore.Domain.Entities;
using EduCore.Domain.Enums;

namespace EduCore.Application.Abstracts;

public interface ISectionService
{
    Task<bool> IsSectionOrderExists(Guid CourseId, int Order);
    Task<bool> IsSectionTitleExists(Guid CourseId, string Title);
}
