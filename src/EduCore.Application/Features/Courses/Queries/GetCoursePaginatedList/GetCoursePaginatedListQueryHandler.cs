using AutoMapper;
using EduCore.Application.Bases;
using EduCore.Application.Wrappers;
using EduCore.Core.Resources;
using EduCore.Domain.Enums;
using EduCore.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;

namespace EduCore.Core.Features.Courses.Queries.GetCoursePaginatedList;

public sealed class GetCoursePaginatedListQueryHandler(IStringLocalizer<SharedResources> stringLocalizer, IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<GetCoursePaginatedListQuery, Result<PaginatedResult<GetCoursePaginatedListResponse>>>
{
    public async Task<Result<PaginatedResult<GetCoursePaginatedListResponse>>> Handle(GetCoursePaginatedListQuery request, CancellationToken cancellationToken)
    {
        var queryable = unitOfWork.Courses.GetTableNoTracking().Include(c => c.Category).Include(c => c.Instructor).Include(c => c.Sections).AsQueryable();

        queryable = request.OrderBy switch
        {
            CourseOrderingEnum.Title => queryable.OrderBy(c => c.Title),
            CourseOrderingEnum.Price => queryable.OrderBy(c => c.Price),
            CourseOrderingEnum.AverageRating => queryable.OrderBy(c => c.AverageRating),
            CourseOrderingEnum.NoOfStudents => queryable.OrderBy(c => c.NoOfStudents),
            _ => queryable
        };

        if (request.Search != null)
        {
            queryable = queryable.Where(c => c.Title.Contains(request.Search));
        }

        var paginatedList = await queryable.Select(x => mapper.Map<GetCoursePaginatedListResponse>(x))
            .ToPaginatedListAsync(request.pageNumber, request.pageSize);
        return paginatedList;
    }
}
