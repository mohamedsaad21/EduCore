using EduCore.Application.Bases;
using EduCore.Domain.Entities.Identity;
using EduCore.Domain.Results;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EduCore.Application.Features.Authorization.Queries.ManageUserRoles;

public sealed class ManageUserRolesQueryHandler(UserManager<User> userManager, RoleManager<Role> roleManager) : IRequestHandler<ManageUserRolesQuery, Result<ManageUserRolesResponse>>
{
    public async Task<Result<ManageUserRolesResponse>> Handle(ManageUserRolesQuery request, CancellationToken cancellationToken)
    {
        var user = await userManager.FindByIdAsync(request.UserId.ToString());
        if (user == null)
            return Errors.UserNotFound;

        var result = new ManageUserRolesResponse();
        result.UserId = user.Id;
        var roles = await roleManager.Roles.ToListAsync();
        var userRoles = await userManager.GetRolesAsync(user);
        var managedUserRoles = new List<UserRoleResponse>();
        foreach (var role in roles)
        {
            managedUserRoles.Add(new UserRoleResponse { RoleName = role.Name, HasRole = userRoles.Any(r => r.Equals(role.Name)) });
        }
        result.Roles = managedUserRoles;
        return result;
    }
}