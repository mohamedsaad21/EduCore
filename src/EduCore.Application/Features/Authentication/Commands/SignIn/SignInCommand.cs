using EduCore.Application.Bases;
using EduCore.Domain.Helpers;
using MediatR;

namespace EduCore.Application.Features.Authentication.Commands.SignIn;

public sealed record SignInCommand
    (
        string Email,
        string Password
    ) : IRequest<Result<AuthResponse>>;