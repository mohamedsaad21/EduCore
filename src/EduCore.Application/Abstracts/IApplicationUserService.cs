using EduCore.Domain.Entities.Identity;
using EduCore.Domain.Enums;

namespace EduCore.Application.Abstracts;

public interface IApplicationUserService
{
    Task<bool> IsUserNameExistsExcludeSelfAsync(Guid Id, string UserName);
    IQueryable<User> GetUserPaginatedListQueryable(UserOrderingEnum Ordering, string Search);
}
