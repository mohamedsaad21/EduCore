using EduCore.Application.Bases;
using EduCore.Domain.Helpers;
using MediatR;

namespace Fixy.Application.Features.Authentication.Commands.SignInWithGoogle;

public sealed record SignInWithGoogleCommand
    (
        string IdToken
    ) : IRequest<Result<AuthResponse>>;