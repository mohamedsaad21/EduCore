using EduCore.Application.Bases;
using EduCore.Core.Resources;
using EduCore.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace EduCore.Application.Features.Authentication.Queries.ConfirmEmail;

public sealed class ConfirmEmailQueryHandler(UserManager<User> userManager) : IRequestHandler<ConfirmEmailQuery, Result>
{
    public async Task<Result> Handle(ConfirmEmailQuery request, CancellationToken cancellationToken)
    {
        var user = await userManager.FindByEmailAsync(request.Email);
        if (user == null)
            return Errors.UserNotFound;

        if (user.Code != request.Code)
            return Errors.InvalidCode;

        user.EmailConfirmed = true;
        var result = await userManager.UpdateAsync(user);
        if (!result.Succeeded)
            return Errors.IdentityConfirmEmailFailed;
        return Result.Success();
    }
}