using EduCore.Application.Bases;
using MediatR;

namespace EduCore.Application.Features.Authentication.Commands.ResetPassword;

public sealed record ResetPasswordCommand
    (
        string Email,
        string Password,
        string ConfirmPassword
    ) : IRequest<Result>;
