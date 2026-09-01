using EduCore.Application.Bases;
using MediatR;

namespace EduCore.Application.Features.Authentication.Queries.ConfirmResetPassword;

public sealed record ConfirmResetPasswordQuery(string Email, string Code) : IRequest<Result>;