using EduCore.Application.Bases;
using EduCore.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace EduCore.Application.Features.Authorization.Commands.UpdateUserRoles;

public sealed class UpdateUserRolesCommandHandler(UserManager<User> userManager) : IRequestHandler<UpdateUserRolesCommand, Result>
{
    public async Task<Result> Handle(UpdateUserRolesCommand request, CancellationToken cancellationToken)
    {
        var user = await userManager.FindByIdAsync(request.UserId.ToString());
        var userRoles = await userManager.GetRolesAsync(user);
        await userManager.RemoveFromRolesAsync(user, userRoles);
        foreach (var role in request.Roles)
        {
            if (role.HasRole)
                await userManager.AddToRoleAsync(user, role.RoleName);
        }
        await userManager.UpdateAsync(user);

        return Result.Success();        
    }
}
