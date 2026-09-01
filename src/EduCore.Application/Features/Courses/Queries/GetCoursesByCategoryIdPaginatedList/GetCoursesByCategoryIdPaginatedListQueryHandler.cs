using AutoMapper;
using EduCore.Application.Abstracts;
using EduCore.Application.Bases;
using EduCore.Application.Wrappers;
using EduCore.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EduCore.Core.Features.Courses.Queries.GetCoursesByCategoryIdPaginatedList;

public sealed class GetCoursesByCategoryIdPaginatedListQueryHandler(ICourseService courseService, IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<GetCoursesByCategoryIdPaginatedListQuery, Result<PaginatedResult<GetCoursesByCategoryIdPaginatedListResponse>>>
{
    public async Task<Result<PaginatedResult<GetCoursesByCategoryIdPaginatedListResponse>>> Handle(GetCoursesByCategoryIdPaginatedListQuery request, CancellationToken cancellationToken)
    {
        var category = await unitOfWork.Categories.GetTableNoTracking().FirstOrDefaultAsync(x => x.Id == request.CategoryId);
        if (category == null)
            return Errors.CategoryNotFound;

        var FilterQuery = courseService.GetPaginatedListByCategoryIdAsync(request.CategoryId, request.OrderBy, request.Search);
        var paginatedList = await FilterQuery.Select(x => mapper.Map<GetCoursesByCategoryIdPaginatedListResponse>(x)).ToPaginatedListAsync(request.pageNumber, request.pageSize);
        paginatedList.Meta = new
        {
            CategoryName = category.Localize(category.NameAr, category.NameEn),
            CategoryThumbnailUrl = category.ThumbnailUrl
        };
        return paginatedList;
    }
}