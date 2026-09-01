using EduCore.Application.Bases;
using EduCore.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace EduCore.Application.Features.Authorization.Commands.DeleteRole;

public sealed class DeleteRoleCommandHandler(RoleManager<Role> roleManager) : IRequestHandler<DeleteRoleCommand, Result>
{
    public async Task<Result> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
    {
        var role = await roleManager.FindByIdAsync(request.Id.ToString());
        if (role == null)
            return Errors.RoleNotFound;

        var result = await roleManager.DeleteAsync(role);
        if (!result.Succeeded)
            return Errors.IdentityDeleteRoleFailed;
        return Result.Success();
    }
}
