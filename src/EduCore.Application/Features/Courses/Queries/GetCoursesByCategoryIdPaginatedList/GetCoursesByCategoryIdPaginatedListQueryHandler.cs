using EduCore.Application.Abstracts;
using EduCore.Application.Bases;
using EduCore.Application.Wrappers;
using EduCore.Domain.Entities;
using EduCore.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EduCore.Core.Features.Courses.Queries.GetCoursesByCategoryIdPaginatedList;

public sealed class GetCoursesByCategoryIdPaginatedListQueryHandler(ICourseService courseService, IUnitOfWork unitOfWork) : IRequestHandler<GetCoursesByCategoryIdPaginatedListQuery, Result<PaginatedResult<GetCoursesByCategoryIdPaginatedListResponse>>>
{
    public async Task<Result<PaginatedResult<GetCoursesByCategoryIdPaginatedListResponse>>> Handle(GetCoursesByCategoryIdPaginatedListQuery request, CancellationToken cancellationToken)
    {
        var category = await unitOfWork.Categories.GetTableNoTracking().FirstOrDefaultAsync(x => x.Id == request.CategoryId);
        if (category == null)
            return Errors.CategoryNotFound;

        Expression<Func<Course, GetCoursesByCategoryIdPaginatedListResponse>> expression =
    e => new GetCoursesByCategoryIdPaginatedListResponse(e.Id, e.Title, e.Description, e.ThumbnailUrl, e.Price, e.Status.ToString(), e.Instructor.FullName, e.Instructor.ProfilePictureUrl, e.CreatedAt, e.AverageRating, e.RatingCount, e.NoOfStudents, e.UpdatedAt);
        var FilterQuery = courseService.GetPaginatedListByCategoryIdAsync(request.CategoryId, request.OrderBy, request.Search);
        var paginatedList = await FilterQuery.Select(expression).ToPaginatedListAsync(request.pageNumber, request.pageSize);
        paginatedList.Meta = new
        {
            CategoryName = category.Localize(category.NameAr, category.NameEn),
            CategoryThumbnailUrl = category.ThumbnailUrl
        };
        return paginatedList;
    }
}