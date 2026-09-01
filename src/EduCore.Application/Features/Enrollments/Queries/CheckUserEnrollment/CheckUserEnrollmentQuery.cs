using EduCore.Application.Bases;
using MediatR;

namespace EduCore.Core.Features.Enrollments.Queries.CheckUserEnrollment;

public sealed record CheckUserEnrollmentQuery(Guid CourseId) : IRequest<Result<bool>>;