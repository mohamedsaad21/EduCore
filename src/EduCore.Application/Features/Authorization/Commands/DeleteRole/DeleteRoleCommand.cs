using EduCore.Application.Bases;
using MediatR;

namespace EduCore.Application.Features.Authorization.Commands.DeleteRole;

public sealed record DeleteRoleCommand(Guid Id) : IRequest<Result>;