using EduCore.Application.Abstracts;
using EduCore.Domain.Entities.Identity;
using EduCore.Domain.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EduCore.Service.Implementation;

public class ApplicationUserService : IApplicationUserService
{
    private readonly UserManager<User> _userManager;

    public ApplicationUserService(UserManager<User> userManager)
    {
        _userManager = userManager;
    }        

    public async Task<bool> IsUserNameExistsExcludeSelfAsync(Guid Id, string UserName)
    {
        var user = await _userManager.Users.FirstOrDefaultAsync(u => u.UserName == UserName && u.Id != Id);
        return user != null;
    }

    public IQueryable<User> GetUserPaginatedListQueryable(UserOrderingEnum Ordering, string Search)
    {
        var queryable = _userManager.Users.AsQueryable();

        if(Search != null)
        {
            queryable = queryable.Where(u => u.FullName.Contains(Search) || u.UserName.Contains(Search) || u.Email.Contains(Search));
        }
        switch (Ordering)
        {
            case UserOrderingEnum.fullName: queryable = queryable.OrderBy(u => u.FullName); break;
            case UserOrderingEnum.userName: queryable = queryable.OrderBy(u => u.UserName); break;
            case UserOrderingEnum.Email: queryable = queryable.OrderBy(u => u.Email); break;
        }
        return queryable;
    }
}
