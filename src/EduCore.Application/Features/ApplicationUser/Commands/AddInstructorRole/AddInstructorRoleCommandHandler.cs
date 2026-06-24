using EduCore.Application.Abstracts;
using EduCore.Application.Bases;
using EduCore.Domain.Entities.Identity;
using EduCore.Domain.Helpers;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace EduCore.Application.Features.ApplicationUser.Commands.AddInstructorRole;

public sealed class AddInstructorRoleCommandHandler(UserManager<User> userManager, ICurrentUserService currentUserService) : IRequestHandler<AddInstructorRoleCommand, Result>
{
    public async Task<Result> Handle(AddInstructorRoleCommand request, CancellationToken cancellationToken)
    {
        var user = await currentUserService.GetCurrentUserAsync();
        var userRoles = await currentUserService.GetCurrentUserRolesAsync();
        if (userRoles.Any(r => r == Roles.Instructor))
            return Errors.UserIsAlreadyInstructor;

        var result = await userManager.AddToRoleAsync(user, Roles.Instructor);
        if (!result.Succeeded)
            return Errors.IdentityAddRoleFailed;

        return Result.Success();
    }
}
