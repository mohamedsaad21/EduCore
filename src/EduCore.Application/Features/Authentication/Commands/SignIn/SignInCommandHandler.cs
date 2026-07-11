using EduCore.Application.Abstracts;
using EduCore.Application.Bases;
using EduCore.Application.Common.DTOs.Auth;
using EduCore.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace EduCore.Application.Features.Authentication.Commands.SignIn;

public sealed class SignInCommandHandler(UserManager<User> userManager, IAuthenticationService authenticationService) : IRequestHandler<SignInCommand, Result<AuthResponse>>
{
    public async Task<Result<AuthResponse>> Handle(SignInCommand request, CancellationToken cancellationToken)
    {
        var user = await userManager.FindByEmailAsync(request.Email);
        if (user == null || !await userManager.CheckPasswordAsync(user, request.Password))
            return Errors.EmailOrPasswordInCorrect;

        if (!user.EmailConfirmed)
            return Errors.EmailNotConfirmed;

        var authResponse = await authenticationService.GetJwtToken(user);
        return authResponse;
    }
}
