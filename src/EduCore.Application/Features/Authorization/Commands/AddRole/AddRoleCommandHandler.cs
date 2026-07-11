using EduCore.Application.Bases;
using EduCore.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace EduCore.Application.Features.Authorization.Commands.AddRole;

public sealed class AddRoleCommandHandler(RoleManager<Role> roleManager) : IRequestHandler<AddRoleCommand, Result>
{
    public async Task<Result> Handle(AddRoleCommand request, CancellationToken cancellationToken)
    {
        var role = new Role(request.Role);
        var result = await roleManager.CreateAsync(role);

        if (!result.Succeeded) 
            return Errors.IdentityAddRoleFailed;

        return Result.Success();
    }
}
