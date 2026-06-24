using EduCore.Application.Bases;
using EduCore.Domain.Helpers;
using MediatR;

namespace EduCore.Application.Features.Authentication.Commands.RefreshToken;

public sealed record RefreshTokenCommand(string Token) : IRequest<Result<AuthResponse>>;
