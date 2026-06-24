using EduCore.Application.Bases;
using MediatR;

namespace EduCore.Application.Features.Authorization.Commands.AddRole;

public sealed record AddRoleCommand(string Role) : IRequest<Result>;