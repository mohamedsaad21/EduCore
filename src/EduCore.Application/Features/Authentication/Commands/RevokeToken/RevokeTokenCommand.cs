using EduCore.Application.Bases;
using MediatR;

namespace EduCore.Application.Features.Authentication.Commands.RevokeToken;

public sealed record RevokeTokenCommand(string Token) : IRequest<Result>;