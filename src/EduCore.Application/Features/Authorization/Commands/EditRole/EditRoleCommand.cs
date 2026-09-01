using EduCore.Application.Bases;
using MediatR;

namespace EduCore.Application.Features.Authorization.Commands.EditRole;

public sealed record EditRoleCommand(Guid Id, string Role) : IRequest<Result>;