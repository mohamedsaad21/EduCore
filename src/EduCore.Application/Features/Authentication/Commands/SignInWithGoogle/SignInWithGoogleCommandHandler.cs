using EduCore.Application.Abstracts;
using EduCore.Application.Bases;
using EduCore.Domain.Helpers;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Fixy.Application.Features.Authentication.Commands.SignInWithGoogle;

public sealed class SignInWithGoogleCommandHandler(IAuthenticationService authenticationService, ILogger<SignInWithGoogleCommandHandler> logger) : IRequestHandler<SignInWithGoogleCommand, Result<AuthResponse>>
{
    public async Task<Result<AuthResponse>> Handle(SignInWithGoogleCommand request, CancellationToken cancellationToken)
    {
        var authResponse = await authenticationService.AuthenticateWithGoogleAsync(request.IdToken);
        return authResponse;
    }
}
