using EduCore.Application.Bases;
using MediatR;

namespace EduCore.Application.Features.CourseProgress.Queries.GetCourseProgress;

public sealed record GetCourseProgressQuery(Guid CourseId) : IRequest<Result<GetCourseProgressResponse>>;