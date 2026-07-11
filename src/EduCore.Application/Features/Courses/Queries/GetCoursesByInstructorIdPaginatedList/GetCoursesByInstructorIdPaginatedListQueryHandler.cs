using AutoMapper;
using EduCore.Application.Abstracts;
using EduCore.Application.Bases;
using EduCore.Application.Wrappers;
using EduCore.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EduCore.Core.Features.Courses.Queries.GetCoursesByInstructorIdPaginatedList;

public sealed class GetCoursesByInstructorIdPaginatedListQueryHandler(UserManager<User> userManager, ICourseService courseService, IMapper mapper) : IRequestHandler<GetCoursesByInstructorIdPaginatedListQuery, Result<PaginatedResult<GetCoursesByInstructorIdPaginatedListResponse>>>
{
    public async Task<Result<PaginatedResult<GetCoursesByInstructorIdPaginatedListResponse>>> Handle(GetCoursesByInstructorIdPaginatedListQuery request, CancellationToken cancellationToken)
    {
        var instructor = await userManager.Users.FirstOrDefaultAsync(x => x.Id == request.InstructorId);

        if (instructor == null)
            return Errors.InstructorNotFound;

        var FilterQuery = courseService.GetPaginatedListByInstructorIdAsync(request.InstructorId, request.OrderBy, request.Search);
        var paginatedList = await FilterQuery.Select(x => mapper.Map<GetCoursesByInstructorIdPaginatedListResponse>(x)).ToPaginatedListAsync(request.pageNumber, request.pageSize);
        return paginatedList;
    }
}