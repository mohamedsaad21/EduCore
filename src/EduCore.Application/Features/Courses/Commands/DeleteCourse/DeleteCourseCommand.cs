using EduCore.Application.Bases;
using MediatR;

namespace EduCore.Application.Features.Courses.Commands.DeleteCourse;

public sealed record DeleteCourseCommand(Guid Id) : IRequest<Result>;
