using EduCore.Application.Bases;
using MediatR;

namespace EduCore.Application.Features.Sections.Queries.GetCourseSectionsList;

public sealed record GetCourseSectionsListQuery
    (
        Guid CourseId
    ) : IRequest<Result<List<GetCourseSectionsListResponse>>>;
