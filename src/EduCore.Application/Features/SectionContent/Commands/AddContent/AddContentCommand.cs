using EduCore.Application.Bases;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace EduCore.Application.Features.SectionContent.Commands.AddContent;

public sealed record AddContentCommand
    (
        string Title,
        Guid SectionId,
        IFormFile File,
        string ResourceType,
        double? Duration
    ) : IRequest<Result<Guid>>;