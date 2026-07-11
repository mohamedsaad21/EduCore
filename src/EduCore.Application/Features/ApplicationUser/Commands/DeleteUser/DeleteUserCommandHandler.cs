using EduCore.Application.Bases;
using EduCore.Core.Resources;
using EduCore.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace EduCore.Application.Features.ApplicationUser.Commands.DeleteUser;

public sealed class DeleteUserCommandHandler(UserManager<User> userManager) : IRequestHandler<DeleteUserCommand, Result>
{
    public async Task<Result> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var user = await userManager.FindByIdAsync(request.Id.ToString());
        if (user == null) return Errors.UserNotFound;

        var result = await userManager.DeleteAsync(user);

        if (!result.Succeeded)
            return Errors.IdentityEditUserFailed;

        return Result.Success();
    }
}
