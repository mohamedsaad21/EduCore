using EduCore.Application.Bases;
using EduCore.Application.Common.DTOs.Auth;
using MediatR;

namespace Fixy.Application.Features.Authentication.Commands.SignInWithGoogle;

public sealed record SignInWithGoogleCommand
    (
        string IdToken
    ) : IRequest<Result<AuthResponse>>;