using EduCore.Application.Bases;
using MediatR;

namespace EduCore.Application.Features.Payment.Commands.WebHook;

public sealed record WebHookCommand(string Payload, string Signature) : IRequest<Result>;
