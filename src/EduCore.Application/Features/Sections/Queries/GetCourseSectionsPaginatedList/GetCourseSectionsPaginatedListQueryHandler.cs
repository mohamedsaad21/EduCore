using AutoMapper;
using EduCore.Application.Bases;
using EduCore.Application.Wrappers;
using EduCore.Domain.Enums;
using EduCore.Domain.Interfaces;
using MediatR;

namespace EduCore.Application.Features.Sections.Queries.GetCourseSectionsPaginatedList;

public sealed class GetCourseSectionsPaginatedListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<GetCourseSectionsPaginatedListQuery, Result<PaginatedResult<GetCourseSectionsPaginatedListResponse>>>
{
    public async Task<Result<PaginatedResult<GetCourseSectionsPaginatedListResponse>>> Handle(GetCourseSectionsPaginatedListQuery request, CancellationToken cancellationToken)
    {
        var queryable = unitOfWork.Sections.GetTableNoTracking().Where(x => x.CourseId == request.CourseId).AsQueryable();
        
        switch (request.OrderBy)
        {
            case SectionOrderingEnum.Title: queryable.OrderBy(x => x.Title); break;
            case SectionOrderingEnum.Order: queryable.OrderBy(x => x.Order); break;
        }

        if (!string.IsNullOrEmpty(request.Search))
        {
            queryable = queryable.Where(x => x.Title.Contains(request.Search));
        }

        var paginatedList = await queryable.Select(x => mapper.Map<GetCourseSectionsPaginatedListResponse>(x)).ToPaginatedListAsync(request.PageNumber, request.PageSize);
        return paginatedList;
    }
}
