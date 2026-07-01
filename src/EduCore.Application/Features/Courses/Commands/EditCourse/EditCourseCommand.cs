using EduCore.Application.Bases;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace EduCore.Application.Features.Courses.Commands.EditCourse;

public sealed record EditCourseCommand
    (
        Guid Id,
        string Title, 
        string Description, 
        IFormFile? Thumbnail,
        int? TotalHours,
        decimal Price, 
        int DiscountPercentage, 
        int CategoryId
    ) : IRequest<Result>;
