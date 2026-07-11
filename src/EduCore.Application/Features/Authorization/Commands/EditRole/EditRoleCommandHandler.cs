using EduCore.Application.Bases;
using EduCore.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace EduCore.Application.Features.Authorization.Commands.EditRole;

public sealed class EditRoleCommandHandler(RoleManager<Role> roleManager) : IRequestHandler<EditRoleCommand, Result>
{
    public async Task<Result> Handle(EditRoleCommand request, CancellationToken cancellationToken)
    {
        var role = await roleManager.FindByIdAsync(request.Id.ToString());
        if (role == null)
            return Errors.RoleNotFound;
        role.Name = request.Role;
        var result = await roleManager.UpdateAsync(role);

        if (!result.Succeeded)
            return Errors.IdentityEditRoleFailed;
        return Result.Success();
    }
}
