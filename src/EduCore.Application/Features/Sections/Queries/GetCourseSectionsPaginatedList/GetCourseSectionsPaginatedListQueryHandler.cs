using EduCore.Application.Abstracts;
using EduCore.Application.Bases;
using EduCore.Application.Wrappers;
using EduCore.Domain.Entities;
using MediatR;
using System.Linq.Expressions;

namespace EduCore.Application.Features.Sections.Queries.GetCourseSectionsPaginatedList;

public sealed class GetCourseSectionsPaginatedListQueryHandler(ISectionService sectionService) : IRequestHandler<GetCourseSectionsPaginatedListQuery, Result<PaginatedResult<GetCourseSectionsPaginatedListResponse>>>
{
    public async Task<Result<PaginatedResult<GetCourseSectionsPaginatedListResponse>>> Handle(GetCourseSectionsPaginatedListQuery request, CancellationToken cancellationToken)
    {
        Expression<Func<Section, GetCourseSectionsPaginatedListResponse>> expression = e => new GetCourseSectionsPaginatedListResponse(e.Id, e.Title, e.Order, e.CourseId);
        var FilterQuery = sectionService.GetCourseSectionsPaginatedList(request.CourseId, request.OrderBy, request.Search);
        var paginatedList = await FilterQuery.Select(expression).ToPaginatedListAsync(request.PageNumber, request.PageSize);
        return paginatedList;
    }
}
