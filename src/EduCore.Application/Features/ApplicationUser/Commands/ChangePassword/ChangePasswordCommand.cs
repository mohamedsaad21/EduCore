using EduCore.Application.Bases;
using MediatR;

namespace EduCore.Application.Features.ApplicationUser.Commands.ChangePassword;

public sealed record ChangePasswordCommand
    (
        string Email,
        string CurrentPassword,
        string NewPassword,
        string ConfirmNewPassword
    ) : IRequest<Result>;