using EduCore.Application.Bases;
using MediatR;

namespace EduCore.Application.Features.Authentication.Queries.ConfirmEmail;

public sealed record ConfirmEmailQuery(string Email, string Code) : IRequest<Result>;