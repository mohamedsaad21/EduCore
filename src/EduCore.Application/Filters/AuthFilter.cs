using EduCore.Application.Abstracts;
using EduCore.Domain.Entities.Identity;
using EduCore.Domain.Helpers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EduCore.Core.Filters;

public class AuthFilter : IAsyncActionFilter
{
    private readonly ICurrentUserService _currentUserService;
    private readonly UserManager<User> _userManager;
    public AuthFilter(ICurrentUserService currentUserService, UserManager<User> userManager)
    {
        _currentUserService = currentUserService;
        _userManager = userManager;
    }

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var user = await _currentUserService.GetCurrentUserAsync();
        var userRoles = await _userManager.GetRolesAsync(user);
        if(!userRoles.Any(r => r == Roles.Instructor))
        {
            throw new UnauthorizedAccessException("User does not have Instructor role");
        }
        else
        {
            await next();
        }
    }
}
