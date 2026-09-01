using EduCore.Application.Bases;
using EduCore.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace EduCore.Application.Features.Authentication.Commands.ResetPassword;

public sealed class ResetPasswordCommandHandler(UserManager<User> userManager) : IRequestHandler<ResetPasswordCommand, Result>
{
    public async Task<Result> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
    {
        var user = await userManager.FindByEmailAsync(request.Email);

        if (user == null)
            return Errors.UserNotFound;

        // Check if new password is the same as the current one
        if (user.PasswordHash is not null)
        {
            var isSamePassword = userManager.PasswordHasher.VerifyHashedPassword(user, user.PasswordHash, request.Password)
                != PasswordVerificationResult.Failed;

            if (isSamePassword)
                return Errors.PasswordPreviouslyUsed;
        }

        await userManager.RemovePasswordAsync(user);

        if (!await userManager.HasPasswordAsync(user))
        {
            await userManager.AddPasswordAsync(user, request.Password);
        }
        return Result.Success();        
    }
}