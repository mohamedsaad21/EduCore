using EduCore.Application.Abstracts;
using EduCore.Application.Bases;
using EduCore.Application.Wrappers;
using EduCore.Domain.Entities.Identity;
using MediatR;
using System.Linq.Expressions;

namespace EduCore.Application.Features.ApplicationUser.Queries.GetUsersPaginatedList;

public sealed class GetUsersPaginatedListQueryHandler(IApplicationUserService applicationUserService) : IRequestHandler<GetUsersPaginatedListQuery, Result<PaginatedResult<GetUsersPaginatedListResponse>>>
{
    public async Task<Result<PaginatedResult<GetUsersPaginatedListResponse>>> Handle(GetUsersPaginatedListQuery request, CancellationToken cancellationToken)
    {
        Expression<Func<User, GetUsersPaginatedListResponse>> expression = e => new GetUsersPaginatedListResponse(e.Id, e.FullName, e.UserName, e.Email, e.ProfilePictureUrl);
        var FilterQuery = applicationUserService.GetUserPaginatedListQueryable(request.OrderBy, request.Search);
        var paginatedList = await FilterQuery.Select(expression).ToPaginatedListAsync(request.PageNumber, request.PageSize);
        return paginatedList;
    }
}
