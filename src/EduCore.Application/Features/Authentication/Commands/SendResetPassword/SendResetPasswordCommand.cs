using EduCore.Application.Bases;
using MediatR;

namespace EduCore.Application.Features.Authentication.Commands.SendResetPassword;

public sealed record SendResetPasswordCommand(string Email) : IRequest<Result>;