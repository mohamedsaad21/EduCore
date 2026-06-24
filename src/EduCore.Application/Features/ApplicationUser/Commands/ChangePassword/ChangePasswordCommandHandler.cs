using EduCore.Application.Bases;
using EduCore.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace EduCore.Application.Features.ApplicationUser.Commands.ChangePassword;

public sealed class ChangePasswordCommandHandler(UserManager<User> userManager) : IRequestHandler<ChangePasswordCommand, Result>
{
    public async Task<Result> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
    {
        var user = await userManager.FindByEmailAsync(request.Email);

        if (user == null) 
            return Errors.UserNotFound;

        if (!await userManager.CheckPasswordAsync(user, request.CurrentPassword))
            return Errors.PasswordInCorrect;

        var result = await userManager.ChangePasswordAsync(user, request.CurrentPassword, request.NewPassword);
        if (!result.Succeeded)
            return Errors.IdentityChangePasswordFailed;

        return Result.Success();
    }
}
