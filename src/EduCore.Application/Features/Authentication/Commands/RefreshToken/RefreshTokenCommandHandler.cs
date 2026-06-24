using EduCore.Application.Abstracts;
using EduCore.Application.Bases;
using EduCore.Domain.Entities.Identity;
using EduCore.Domain.Helpers;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EduCore.Application.Features.Authentication.Commands.RefreshToken;

public sealed class RefreshTokenCommandHandler(UserManager<User> userManager, IAuthenticationService authenticationService) : IRequestHandler<RefreshTokenCommand, Result<AuthResponse>>
{
    public async Task<Result<AuthResponse>> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
    {
        var user = await userManager.Users.SingleOrDefaultAsync(u => u.RefreshTokens.Any(t => t.Token == request.Token));

        if (user == null)
            return Errors.InvalidToken;

        var refreshToken = user.RefreshTokens.Single(t => t.Token == request.Token);

        if (!refreshToken.IsActive)
            return Errors.InactiveToken;

        refreshToken.RevokedOn = DateTime.UtcNow;

        var authResponse = await authenticationService.GetJwtToken(user);
        return authResponse;
    }
}
