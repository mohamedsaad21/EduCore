using EduCore.Application.Bases;
using EduCore.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace EduCore.Application.Features.SectionContent.Commands.AddContent;

public sealed record AddContentCommand
    (
        string Title,
        IFormFile File,
        Guid SectionId
    ) : IRequest<Result<Guid>>;