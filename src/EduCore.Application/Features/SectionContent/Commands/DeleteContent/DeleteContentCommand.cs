using EduCore.Application.Bases;
using MediatR;

namespace EduCore.Application.Features.SectionContent.Commands.DeleteContent;

public sealed record DeleteContentCommand(Guid Id) : IRequest<Result>;