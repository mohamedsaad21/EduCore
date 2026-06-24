using EduCore.Application.Bases;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace EduCore.Core.Features.Courses.Commands.AddCourse;

public sealed record AddCourseCommand 
    (
        string Title,
        string Description,
        IFormFile Thumbnail,
        decimal Price,
        int DiscountPercentage,
        Guid CategoryId
    ) : IRequest<Result<Guid>>;