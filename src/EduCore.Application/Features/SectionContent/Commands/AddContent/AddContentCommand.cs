using EduCore.Application.Bases;
using MediatR;

namespace EduCore.Application.Features.SectionContent.Commands.AddContent;

public sealed record AddContentCommand
    (
        string Title,
        Guid SectionId,
        string Url,
        string PublicId,
        string ResourceType,
        double? Duration
    ) : IRequest<Result<Guid>>;