using EduCore.Application.Bases;
using MediatR;

namespace EduCore.Application.Features.ApplicationUser.Commands.AddInstructorRole;

public sealed record AddInstructorRoleCommand() : IRequest<Result>;