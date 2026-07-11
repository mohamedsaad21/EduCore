using EduCore.Application.Bases;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace EduCore.Core.Features.Category.Commands.Models;

public sealed record AddCategoryCommand
    (
        string NameEn,
        string NameAr,
        IFormFile? Thumbnail
    )
    : IRequest<Result<Guid>>;