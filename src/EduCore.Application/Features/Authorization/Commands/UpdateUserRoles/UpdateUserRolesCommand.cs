using EduCore.Application.Bases;
using EduCore.Domain.Results;
using MediatR;

namespace EduCore.Application.Features.Authorization.Commands.UpdateUserRoles;

public sealed record UpdateUserRolesCommand(Guid UserId, List<UserRole> Roles) : IRequest<Result>;