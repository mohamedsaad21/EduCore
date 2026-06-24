using EduCore.Application.Bases;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace EduCore.Application.Features.SectionContent.Commands.EditContent;

public sealed record EditContentCommand
    (
        Guid Id,
        string Title,
        IFormFile? Attachment,
        Guid SectionId
    ) : IRequest<Result>;