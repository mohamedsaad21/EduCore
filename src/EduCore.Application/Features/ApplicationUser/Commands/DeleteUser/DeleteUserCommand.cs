using EduCore.Application.Bases;
using MediatR;

namespace EduCore.Application.Features.ApplicationUser.Commands.DeleteUser;

public sealed record DeleteUserCommand(Guid Id) : IRequest<Result>;