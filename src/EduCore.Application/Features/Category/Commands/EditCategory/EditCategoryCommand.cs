using EduCore.Application.Bases;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace EduCore.Application.Features.Category.Commands.EditCategory;

public sealed record EditCategoryCommand
    (
        Guid Id, 
        string NameEn,
        string NameAr,
        IFormFile? Thumbnail
    ) : IRequest<Result>;