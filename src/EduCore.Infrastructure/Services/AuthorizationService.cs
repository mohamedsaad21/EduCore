using EduCore.Application.Abstracts;
using EduCore.Domain.Entities.Identity;
using EduCore.Infrastructure.Persistence;
using Microsoft.AspNetCore.Identity;

namespace EduCore.Infrastructure.Services;

public class AuthorizationService : IAuthorizationService
{
    private readonly RoleManager<Role> _roleManager;

    public AuthorizationService(RoleManager<Role> roleManager, UserManager<User> userManager, ApplicationDbContext dbContext)
    {
        _roleManager = roleManager;
    }
    public async Task<bool> IsRoleExistsAsync(string roleName) => await _roleManager.RoleExistsAsync(roleName);

    public async Task<bool> IsRoleExistsExcludeSelfAsync(Guid Id, string roleName)
    {
        var role = await _roleManager.FindByNameAsync(roleName);
        return role == null || role.Id != Id;
    }
}