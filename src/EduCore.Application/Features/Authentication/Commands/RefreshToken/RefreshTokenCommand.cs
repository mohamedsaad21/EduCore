using EduCore.Application.Bases;
using EduCore.Application.Common.DTOs.Auth;
using MediatR;

namespace EduCore.Application.Features.Authentication.Commands.RefreshToken;

public sealed record RefreshTokenCommand(string Token) : IRequest<Result<AuthResponse>>;
