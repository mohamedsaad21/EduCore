using System.Net.Mime;
using EduCore.Application.Bases;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using ContentType = EduCore.Domain.Enums.ContentType;

namespace EduCore.Application.Features.SectionContent.Commands.AddContent;

public sealed record AddContentCommand
    (
        string Title,
        Guid SectionId,
        IFormFile File,
        ContentType Type 
    ) : IRequest<Result<Guid>>;