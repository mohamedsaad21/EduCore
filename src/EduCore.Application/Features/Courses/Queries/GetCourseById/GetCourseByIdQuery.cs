using EduCore.Application.Bases;
using MediatR;

namespace EduCore.Application.Features.Courses.Queries.GetCourseById;

public sealed record GetCourseByIdQuery(Guid Id) : IRequest<Result<GetCourseByIdResponse>>;